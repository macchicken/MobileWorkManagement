using FineUI;
using Int.AC.ReadModel.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace Int.WebUI.Sys
{
    public partial class SelectDepartment : BasePage
    {
        public IDepartmentDao departmentDao { get; set; }
        List<Department> departmentList = new List<Department>();
        int currentId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tvwDepartment_Bind();
                if (!string.IsNullOrWhiteSpace(Request.QueryString["ID"]))
                {
                    int id = int.Parse(Request.QueryString["ID"]);
                    currentId = id;
                    TreeExpandNodes(tvwDepartment.Nodes);
                }
            }
        }

        /// <summary>
        /// 递归设置节点
        /// </summary>
        private void TreeExpandNodes(FineUI.TreeNodeCollection treeNodes)
        {
            foreach (FineUI.TreeNode node in treeNodes)
            {
                if (int.Parse(node.NodeID) == currentId)
                {
                    if (node.ParentNode != null && node.ParentNode.Enabled == false)
                        node.Enabled = false;
                }
                TreeExpandNodes(node.Nodes);
            }
        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            if (tvwDepartment.SelectedNode != null)
            {
                FineUI.TreeNode node = tvwDepartment.SelectedNode;
                PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(node.Text, node.NodeID) + ActiveWindow.GetHideReference());
            }
        }

        /// <summary>
        /// 收起全部
        /// </summary>
        protected void btnCollapseAll_Click(object sender, EventArgs e)
        {
            tvwDepartment.CollapseAllNodes();
        }

        /// <summary>
        /// 展开全部
        /// </summary>
        protected void btnExpandAll_Click(object sender, EventArgs e)
        {
            tvwDepartment.ExpandAllNodes();
        }

        /// <summary>
        /// 取消选择
        /// </summary>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference("", "") + ActiveWindow.GetHideReference());
        }

        private void tvwDepartment_Bind()
        {
            departmentList = departmentDao.Entities.ToList();
            List<Department> tempList = departmentList.Where(m => m.ParentId == null).ToList();
            XDocument xdoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Tree"));

            foreach (var model in tempList)
            {
                XElement xe = new XElement("TreeNode", new object[] 
                { 
                    new XAttribute("Text", model.Name),
                    new XAttribute("SingleClickExpand", false),
                    new XAttribute("NodeID",model.Id)
                });
                xdoc.Root.Add(xe);
                CreateXElement(xe, model);
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xdoc.Document.ToString());
            tvwDepartment.DataSource = xmlDoc;
            tvwDepartment.DataBind();
        }

        private void CreateXElement(XElement root, Department model)
        {
            var tempList = departmentList.Where(m => m.ParentId == model.Id).ToList();
            foreach (var temp in tempList)
            {
                XElement xe = new XElement("TreeNode", new object[] 
            { 
                new XAttribute("Text", temp.Name),
                new XAttribute("SingleClickExpand", false),
                new XAttribute("NodeID",temp.Id),                
            });
                root.Add(xe);
                CreateXElement(xe, temp);
            }
        }
    }
}