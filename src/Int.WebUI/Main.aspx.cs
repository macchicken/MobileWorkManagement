using FineUI;
using Int.AC.ReadModel.Menus;
using Int.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace Int.WebUI.Pages
{
    public partial class Main : BasePage
    {
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CheckTopMenu();
                InitMenu(10000);
                lbUser.Text = PersonnelName;
                lblVersion.Text = "版本：" + ConfigHelper.GetStringProperty("Version", "1.0");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void CheckTopMenu()
        {
            if (MenuList.Count(m => m.Sort == 1) > 0)
            {
                liSys.Visible = true;
            }
            if (MenuList.Count(m => m.Sort == 13) > 0)
            {
                liSz.Visible = true;
            }
        }

        private void InitMenu(int sort)
        {
            XDocument xdoc = CreateMenuXml(sort);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xdoc.Document.ToString());

            leftMenuTree.DataSource = xmlDoc;
            leftMenuTree.DataBind();
            leftMenuTree.ExpandAllNodes();
        }

        private XDocument CreateMenuXml(int sort)
        {
            //只有一个根菜单
            var rootMenu = MenuList.Where(m => m.Sort == sort).SingleOrDefault();
            var tempList = MenuList.Where(m => m.ParentId == rootMenu.Id).OrderBy(s => s.Sort).ToList();
            XDocument xdoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Tree"));
            foreach (var item in tempList)
            {
                XElement sub = new XElement("TreeNode", new object[] 
                { 
                    new XAttribute("Text", item.Text), 
                    new XAttribute("NodeID",item.Id),                
                });
                xdoc.Root.Add(sub);
                if (item.NavigateUrl != null)
                {
                    object[] xas = new object[] 
                    { 
                        new XAttribute("NavigateUrl", item.NavigateUrl) 
                    };
                    sub.Add(xas);
                }
                CreateXElement(sub, item);
            }
            return xdoc;
        }

        private void CreateXElement(XElement root, MenuInfo model)
        {
            var tempList = MenuList.Where(m => m.ParentId == model.Id).OrderBy(s => s.Sort).ToList();
            foreach (var temp in tempList)
            {
                XElement xe = new XElement("TreeNode", new object[] 
                { 
                    new XAttribute("Text", temp.Text), 
                    new XAttribute("NodeID",temp.Id),                
                });
                root.Add(xe);
                if (temp.NavigateUrl != null)
                {
                    object[] xas = new object[] 
                    { 
                        new XAttribute("NavigateUrl", temp.NavigateUrl) 
                    };
                    xe.Add(xas);
                }
                CreateXElement(xe, temp);
            }
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Session.Clear();
            PageContext.Redirect("Default.aspx");
        }

        protected void linkMenu_Click(object sender, EventArgs e)
        {
            var btn = sender as System.Web.UI.WebControls.LinkButton;
            string js = @"
document.getElementById('RegionPanel1_Region1_ContentPanel1_liGr').className = '';
document.getElementById('RegionPanel1_Region1_ContentPanel1_liSz').className = '';
document.getElementById('RegionPanel1_Region1_ContentPanel1_liKh').className = '';
document.getElementById('RegionPanel1_Region1_ContentPanel1_liSys').className = '';";
            switch (btn.ID)
            {
                case "linkGr":
                    InitMenu(1);
                    PageContext.RegisterStartupScript(js + " document.getElementById('RegionPanel1_Region1_ContentPanel1_liGr').className = 'inhover';");
                    break;
                case "linkSz":
                    InitMenu(14);
                    PageContext.RegisterStartupScript(js + " document.getElementById('RegionPanel1_Region1_ContentPanel1_liSz').className = 'inhover';");
                    break;
                case "linkKh":
                    InitMenu(25);
                    PageContext.RegisterStartupScript(js + " document.getElementById('RegionPanel1_Region1_ContentPanel1_liKh').className = 'inhover';");
                    break;
                case "linkSys":
                    InitMenu(1);
                    PageContext.RegisterStartupScript(js + " document.getElementById('RegionPanel1_Region1_ContentPanel1_liSys').className = 'inhover';");
                    break;
                default:
                    Alert.Show("该模组处于规划中……");
                    break;
            }
        }
    }
}