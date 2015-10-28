using FineUI;
using Int.AC.ReadModel.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Int.WebUI.Sys
{
    public partial class RoleList : BasePage
    {
        public IRoleDao roleDao { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridBind();

                btnNew.OnClientClick = newRoleWin.GetShowReference();
                btnModify.OnClientClick = roleGrid.GetNoSelectionAlertReference(string.Format("请选择要编辑的{0}！", roleGrid.Title));
                btnPermissionRole.OnClientClick = roleGrid.GetNoSelectionAlertReference(string.Format("请选择要编辑的{0}！", roleGrid.Title));
            }
        }

        /// <summary>
        /// 删除事件
        /// </summary>
        protected void roleGrid_RowCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                //if (e.CommandName == "delete")
                //{
                //    object[] keys = roleGrid.DataKeys[e.RowIndex];
                //    var id = keys[0].ToString();
                //    var model = roleDao.Entities.Where(m => m.Id == id).Select(m => new { UserCount = m.Users.Where(n => !n.IsDeleted).Count(), Name = m.Name }).SingleOrDefault();
                //    if (model == null)
                //    {
                //        Alert.ShowInParent("您要删除的角色不存在。");
                //        return;
                //    }
                //    if (model.UserCount > 0)
                //    {
                //        Alert.ShowInParent("存在关联的帐号，删除失败。");
                //        return;
                //    }
                //    var form = roleDao.Entities.Where(m => m.Id == id).SingleOrDefault();
                //    roleDao.AutoDetectChangesEnabled = true;
                //    form.IsDeleted = true;
                //    roleDao.SaveRole(form);
                //    GridBind();
                //}
            }
            catch (Exception ex)
            {
                Alert.ShowInParent(ex.Message);
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            modifyRoleWin.IFrameUrl = string.Format("ModifyRole.aspx?id={0}", roleGrid.DataKeys[roleGrid.SelectedRowIndex][0]);
            modifyRoleWin.Hidden = false;
        }

        protected void btnPermissionRole_Click(object sender, EventArgs e)
        {
            modifyPermissionRoleWin.IFrameUrl = string.Format("RoleAuthority.aspx?id={0}", roleGrid.DataKeys[roleGrid.SelectedRowIndex][0]);
            modifyPermissionRoleWin.Hidden = false;
        }

        protected void btnUserRole_Click(object sender, EventArgs e)
        {
            viewUserWin.IFrameUrl = string.Format("RoleUser.aspx?id={0}", roleGrid.DataKeys[roleGrid.SelectedRowIndex][0]);
            viewUserWin.Hidden = false;
        }

        private void GridBind()
        {
            var query = roleDao.Entities;
            if (!string.IsNullOrWhiteSpace(ttbSearch.Text.Trim()))
            {
                query = query.Where(m => m.Name.Contains(ttbSearch.Text.Trim()));
            }
            var list = query.OrderBy(m => m.Sort).Skip((roleGrid.PageIndex) * roleGrid.PageSize).Take(roleGrid.PageSize).ToList();
            roleGrid.RecordCount = query.Count();
            roleGrid.DataSource = list;
            roleGrid.DataBind();
        }

        protected void roleGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            this.roleGrid.PageIndex = e.NewPageIndex;
            GridBind();
        }

        protected void ttbSearch_Trigger1Click(object sender, EventArgs e)
        {
            ttbSearch.Text = String.Empty;
            ttbSearch.ShowTrigger1 = false;
            this.roleGrid.PageIndex = 0;
            GridBind();
        }

        protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
        {
            this.roleGrid.PageIndex = 0;
            GridBind();
            ttbSearch.ShowTrigger1 = true;
        }

        protected void subwin_Close(object sender, WindowCloseEventArgs e)
        {
            GridBind();
        }
    }
}