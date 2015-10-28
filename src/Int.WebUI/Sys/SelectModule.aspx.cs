using FineUI;
using Int.AC.ReadModel.Modules;
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
    public partial class SelectModule : BasePage
    {
        List<Module> authorityList = new List<Module>();
        List<Module> unEnabledList = new List<Module>();
        bool forPage = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["forpage"] != null)
                {
                    forPage = true;
                }
                authorityList = moduleDao.Entities.ToList();
                tvwModule_Bind();
                if (Request["id"] != null)
                {
                    this.GetSubList(Request["id"]);
                    TreeExpandNodes(tvwModule.Nodes);
                }
            }
        }

        /// <summary>
        /// 取子节点
        /// </summary>
        /// <param name="authority"></param>
        private void GetSubList(string id)
        {
            var module = moduleDao.Entities.Where(m => m.Id == id).SingleOrDefault();
            unEnabledList.Add(module);
            var tempList = moduleDao.Entities.Where(m => m.ParentId == module.Id).ToList();
            foreach (var a in tempList)
            {
                GetSubList(a.Id);
            }
        }

        /// <summary>
        /// 递归设置节点
        /// </summary>
        private void TreeExpandNodes(FineUI.TreeNodeCollection treeNodes)
        {
            foreach (FineUI.TreeNode node in treeNodes)
            {
                var id = node.NodeID;
                if (unEnabledList.Where(m => m.Id == id).Count() > 0)
                {
                    node.Enabled = false;
                }
                TreeExpandNodes(node.Nodes);
            }
        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            FineUI.TreeNode node = tvwModule.SelectedNode;
            PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(node.Text, node.NodeID) + ActiveWindow.GetHideReference());
        }

        /// <summary>
        /// 收起全部
        /// </summary>
        protected void btnCollapseAll_Click(object sender, EventArgs e)
        {
            tvwModule.CollapseAllNodes();
        }

        /// <summary>
        /// 展开全部
        /// </summary>
        protected void btnExpandAll_Click(object sender, EventArgs e)
        {
            tvwModule.ExpandAllNodes();
        }

        /// <summary>
        /// 取消选择
        /// </summary>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference("", "") + ActiveWindow.GetHideReference());
        }

        /// <summary>
        /// 树模块
        /// </summary>
        private void tvwModule_Bind()
        {
            XDocument xdoc = CreateModuleXml();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xdoc.Document.ToString());
            tvwModule.DataSource = xmlDoc; // 绑定 XML 数据源到树控件
            tvwModule.DataBind();
        }

        /// <summary>
        /// 创建树的XML
        /// </summary>
        private XDocument CreateModuleXml()
        {
            var tempList = authorityList.Where(m => m.ParentId == null).OrderBy(s => s.Sort).ToList();
            XDocument xdoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Tree"));
            foreach (var temp in tempList)
            {
                XElement sub = new XElement("TreeNode", new object[] 
                { 
                    new XAttribute("Text", temp.Text), 
                    new XAttribute("NodeID",temp.Id),                
                });
                xdoc.Root.Add(sub);
                if (forPage && authorityList.Count(m => m.ParentId == temp.Id) > 0)
                {
                    object[] xas = new object[] 
                    { 
                        new XAttribute("Enabled", false), 
                    };
                    sub.Add(xas);
                }
                CreateXElement(sub, temp);
            }
            return xdoc;
        }

        /// <summary>
        /// 创建树第一级节点
        /// </summary>
        private void CreateXElement(XElement root, Module model)
        {
            var tempList = authorityList.Where(m => m.ParentId == model.Id).OrderBy(s => s.Sort).ToList();
            foreach (var temp in tempList)
            {
                XElement xe = new XElement("TreeNode", new object[] 
                { 
                    new XAttribute("Text", temp.Text), 
                    new XAttribute("NodeID",temp.Id),                
                });
                if (forPage && authorityList.Count(m => m.ParentId == temp.Id) > 0)
                {
                    object[] xas = new object[] 
                    { 
                        new XAttribute("Enabled", false), 
                    };
                    xe.Add(xas);
                }
                root.Add(xe);
                CreateXElement(xe, temp);
            }
        }
    }
}