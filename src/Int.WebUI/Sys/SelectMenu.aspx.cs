using FineUI;
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
    public partial class SelectMenu : BasePage
    {
        List<Int.AC.ReadModel.Menus.Menu> authorityList = new List<Int.AC.ReadModel.Menus.Menu>();
        List<Int.AC.ReadModel.Menus.Menu> unEnabledList = new List<Int.AC.ReadModel.Menus.Menu>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                authorityList = menuDao.Entities.ToList();
                tvwMenu_Bind();
                if (Request["id"] != null)
                {
                    this.GetSubList(Request["id"]);
                    TreeExpandNodes(tvwMenu.Nodes);
                }
            }
        }

        /// <summary>
        /// 取子节点
        /// </summary>
        /// <param name="authority"></param>
        private void GetSubList(string id)
        {
            var menu = menuDao.Entities.Where(m => m.Id == id).SingleOrDefault();
            unEnabledList.Add(menu);
            var tempList = menuDao.Entities.Where(m => m.ParentId == menu.Id).ToList();
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
            FineUI.TreeNode node = tvwMenu.SelectedNode;
            PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(node.Text, node.NodeID) + ActiveWindow.GetHideReference());
        }

        /// <summary>
        /// 收起全部
        /// </summary>
        protected void btnCollapseAll_Click(object sender, EventArgs e)
        {
            tvwMenu.CollapseAllNodes();
        }

        /// <summary>
        /// 展开全部
        /// </summary>
        protected void btnExpandAll_Click(object sender, EventArgs e)
        {
            tvwMenu.ExpandAllNodes();
        }

        /// <summary>
        /// 取消选择
        /// </summary>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference("", "") + ActiveWindow.GetHideReference());
        }

        /// <summary>
        /// 树菜单
        /// </summary>
        private void tvwMenu_Bind()
        {
            XDocument xdoc = CreateMenuXml();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xdoc.Document.ToString());
            tvwMenu.DataSource = xmlDoc; // 绑定 XML 数据源到树控件
            tvwMenu.DataBind();
        }

        /// <summary>
        /// 创建树的XML
        /// </summary>
        private XDocument CreateMenuXml()
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
                CreateXElement(sub, temp);
            }
            return xdoc;
        }

        /// <summary>
        /// 创建树第一级节点
        /// </summary>
        private void CreateXElement(XElement root, Int.AC.ReadModel.Menus.Menu model)
        {
            var tempList = authorityList.Where(m => m.ParentId == model.Id).ToList();
            foreach (var temp in tempList)
            {
                XElement xe = new XElement("TreeNode", new object[] 
                { 
                    new XAttribute("Text", temp.Text), 
                    new XAttribute("NodeID",temp.Id),                
                });
                root.Add(xe);
                CreateXElement(xe, temp);
            }
        }
    }
}