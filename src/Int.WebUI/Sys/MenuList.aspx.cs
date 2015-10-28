using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Int.WebUI.Sys
{
    public partial class MenuList : BasePage
    {
        List<Int.AC.ReadModel.Menus.Menu> menuList = new List<Int.AC.ReadModel.Menus.Menu>();
        List<Int.AC.ReadModel.Menus.Menu> treeList = new List<Int.AC.ReadModel.Menus.Menu>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridBind();
                btnNew.OnClientClick = newMenuWin.GetShowReference();
                btnModify.OnClientClick = menuGrid.GetNoSelectionAlertReference(string.Format("请选择要操作的{0}！", this.menuGrid.Title));
            }
        }

        private void GridBind()
        {
            menuList = menuDao.Entities.ToList();
            menuGrid.DataSource = BuildTree();
            menuGrid.DataBind();
        }

        private List<Int.AC.ReadModel.Menus.Menu> BuildTree()
        {
            List<Int.AC.ReadModel.Menus.Menu> tempList = menuList.Where(s => s.ParentId == null).OrderBy(m => m.Sort).ToList();
            foreach (var a in tempList)
            {
                a.TreeLevel = 1;
                treeList.Add(a);
                BuildSubTree(a, 1);
            }
            return treeList;
        }

        private void BuildSubTree(Int.AC.ReadModel.Menus.Menu model, int level)
        {
            var tempList = menuList.Where(s => s.ParentId == model.Id).OrderBy(m => m.Sort).ToList();
            level++;
            foreach (var a in tempList)
            {
                a.TreeLevel = level;
                treeList.Add(a);
                BuildSubTree(a, level);
            }
        }

        /// <summary>
        /// 删除事件
        /// </summary>
        protected void menuGrid_RowCommand(object sender, GridCommandEventArgs e)
        {
            //if (e.CommandName == "delete")
            //{
            //    try
            //    {
            //        object[] keys = menuGrid.DataKeys[e.RowIndex];
            //        var id = int.Parse(keys[0].ToString());
            //        var form = menuApp.Entities.Where(m => m.Id == id).SingleOrDefault();
            //        moduleApp.AutoDetectChangesEnabled = true;
            //        form.IsDeleted = true;
            //        menuApp.SaveMenu(form);
            //        GridBind();
            //    }
            //    catch (Exception ex)
            //    {
            //        Alert.Show(ex.Message);
            //    }
            //}
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            modifyMenuWin.IFrameUrl = string.Format("ModifyMenu.aspx?id={0}", menuGrid.DataKeys[menuGrid.SelectedRowIndex][0]);
            modifyMenuWin.Hidden = false;
        }

        protected void subwin_Close(object sender, WindowCloseEventArgs e)
        {
            GridBind();
        }
    }
}