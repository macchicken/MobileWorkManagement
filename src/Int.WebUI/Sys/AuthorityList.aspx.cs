using FineUI;
using Int.AC.ReadModel.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace Int.WebUI.Sys
{
    public partial class AuthorityList : BasePage
    {
        List<Module> moduleList = new List<Module>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                moduleList = moduleDao.Entities.ToList();
                tvwModuleBind();
                GridBind();

                btnNew.OnClientClick = newAuthorityWin.GetShowReference();
                btnModify.OnClientClick = authorityGrid.GetNoSelectionAlertReference(string.Format("请选择要复制的{0}！", authorityGrid.Title));
            }
        }

        /// <summary>
        /// 树模组
        /// </summary>
        private void tvwModuleBind()
        {
            XDocument xdoc = CreateModuleXml();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xdoc.Document.ToString());

            tvwModule.DataSource = xmlDoc;// 绑定 XML 数据源到树控件
            tvwModule.DataBind();
            tvwModule.Nodes[0].Expanded = true;
        }

        /// <summary>
        /// 创建树的XML
        /// </summary>
        private XDocument CreateModuleXml()
        {
            var tempList = moduleList.Where(m => m.ParentId == null).OrderBy(s => s.Sort).ToList();
            XDocument xdoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Tree"));
            XElement root = new XElement("TreeNode", new object[] 
            { 
                    new XAttribute("Text", "全部模组"), 
                    new XAttribute("NodeID","0"),        
            });
            xdoc.Root.Add(root);
            foreach (var temp in tempList)
            {
                XElement sub = new XElement("TreeNode", new object[] 
                { 
                    new XAttribute("Text", temp.Text), 
                    new XAttribute("EnableClickEvent",true),
                    new XAttribute("NodeID",temp.Id),      
                });
                root.Add(sub);
                CreateXElement(sub, temp);
            }
            return xdoc;
        }

        /// <summary>
        /// 创建树第一级节点
        /// </summary>
        private void CreateXElement(XElement root, Module model)
        {
            var tempList = moduleList.Where(m => m.ParentId == model.Id).OrderBy(s => s.Sort).ToList();
            foreach (var temp in tempList)
            {
                XElement xe = new XElement("TreeNode", new object[] 
                { 
                    new XAttribute("Text", temp.Text), 
                    new XAttribute("EnableClickEvent",true),
                    new XAttribute("NodeID",temp.Id),   
                });
                root.Add(xe);
                CreateXElement(xe, temp);
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            modifyAuthorityWin.IFrameUrl = string.Format("ModifyAuthority.aspx?id={0}", authorityGrid.DataKeys[authorityGrid.SelectedRowIndex][0]);
            modifyAuthorityWin.Hidden = false;
        }

        /// <summary>
        /// 刷新附件信息
        /// </summary>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            GridBind();
        }

        private void GridBind()
        {
            FineUI.TreeNode node = tvwModule.SelectedNode;
            if (node != null && node.NodeID != "0")
            {
                var id = node.NodeID;
                var list = permissionDao.Entities.Where(m => m.ModuleId == id).Select(m => new
                {
                    ModuleText = m.Module.Text,
                    Code = m.Code,
                    Id = m.Id,
                    Name = m.Name
                }).ToList();
                authorityGrid.DataSource = list;
                authorityGrid.DataBind();
            }
            else
            {
                authorityGrid.DataSource = null;
                authorityGrid.DataBind();
            }
        }

        protected void tvwModule_NodeCommand(object sender, TreeCommandEventArgs e)
        {
            GridBind();
        }

        /// <summary>
        /// 全局变量，递归取子节点ID
        /// </summary>
        StringBuilder strNodes = new StringBuilder();

        /// <summary>
        /// 取所有子节点
        /// </summary>
        private string GetSubNodes(FineUI.TreeNode node)
        {
            strNodes.Append(node.NodeID);
            strNodes.Append(",");
            foreach (FineUI.TreeNode temp in node.Nodes)
            {
                GetSubNodes(temp);
            }
            return strNodes.ToString();
        }

        /// <summary>
        /// 展开树节点
        /// </summary>
        protected void btnExpandAll_Click(object sender, EventArgs e)
        {
            tvwModule.ExpandAllNodes();
        }

        /// <summary>
        /// 收起树节点
        /// </summary>
        protected void btnCollapseAll_Click(object sender, EventArgs e)
        {
            tvwModule.CollapseAllNodes();
        }

        protected void subwin_Close(object sender, WindowCloseEventArgs e)
        {
            GridBind();
        }
    }
}