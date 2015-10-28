using ENode.Commanding;
using FineUI;
using Int.AC.Commands.Roles;
using Int.AC.ReadModel.Modules;
using Int.AC.ReadModel.Permissions;
using Int.AC.ReadModel.Roles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Int.WebUI.Sys
{
    public partial class RoleAuthority : BasePage
    {
        public ICommandService commandService { get; set; }
        public IRoleDao roleDao { get; set; }
        List<Permission> permissions = new List<Permission>();
        List<Permission> currentPermissions = new List<Permission>();
        List<Module> moduleList = new List<Module>();
        List<Module> treeList = new List<Module>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var roleId = Request["id"];
                permissions = permissionDao.Entities.ToList();
                currentPermissions = roleDao.Entities.Where(m => m.Id == roleId).Select(m => m.Permissions).SingleOrDefault();
                GridBind();
            }
        }

        private void GridBind()
        {
            moduleList = moduleDao.Entities.ToList();
            authorityGrid.DataSource = BuildTree();
            authorityGrid.DataBind();
        }

        private List<Module> BuildTree()
        {
            List<Module> tempList = moduleList.Where(s => s.ParentId == null).OrderBy(m => m.Sort).ToList();
            foreach (var a in tempList)
            {
                a.TreeLevel = 1;
                treeList.Add(a);
                BuildSubTree(a, 1);
            }
            return treeList;
        }

        private void BuildSubTree(Module model, int level)
        {
            var tempList = moduleList.Where(s => s.ParentId == model.Id).OrderBy(m => m.Sort).ToList();
            level++;
            foreach (var a in tempList)
            {
                a.TreeLevel = level;
                treeList.Add(a);
                BuildSubTree(a, level);
            }
        }

        protected void authorityGrid_RowDataBound(object sender, FineUI.GridRowEventArgs e)
        {
            var chkAuthority = authorityGrid.Rows[e.RowIndex].FindControl("chkAuthority") as System.Web.UI.WebControls.CheckBoxList;
            dynamic row = e.DataItem as dynamic;
            if (row != null)
            {
                var id = row.Id;
                chkAuthority.DataSource = permissions.Where(m => m.ModuleId == id).ToList();
                chkAuthority.DataValueField = "Id";
                chkAuthority.DataTextField = "Name";
                chkAuthority.DataBind();

                foreach (System.Web.UI.WebControls.ListItem item in chkAuthority.Items)
                {
                    var itemId = item.Value;
                    if (currentPermissions.Exists(m => m.Id == itemId))
                    {
                        item.Selected = true;
                    }
                    else
                    {
                        item.Selected = false;
                    }
                }
            }
        }


        protected void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0, count = authorityGrid.Rows.Count; i < count; i++)
            {
                GridRow row = authorityGrid.Rows[i];
                var chkAuthority = (System.Web.UI.WebControls.CheckBoxList)row.FindControl("chkAuthority");
                foreach (System.Web.UI.WebControls.ListItem item in chkAuthority.Items)
                {
                    item.Selected = true;
                }
            }
            authorityGrid.UpdateTemplateFields();
        }

        protected void btnAwardRole_Click(object sender, EventArgs e)
        {
            List<string> authorities = new List<string>();
            for (int i = 0, count = authorityGrid.Rows.Count; i < count; i++)
            {
                GridRow row = authorityGrid.Rows[i];
                var chkAuthority = (System.Web.UI.WebControls.CheckBoxList)row.FindControl("chkAuthority");
                foreach (System.Web.UI.WebControls.ListItem item in chkAuthority.Items)
                {
                    if (item.Selected)
                    {
                        authorities.Add(item.Value);
                    }
                }
            }
            var roleId = Request["id"];
            try
            {
                commandService.Send(new SetRolePermissions(roleId, authorities.ToArray()));
                Session["AuthorityList"] = null;
                Session["MenuList"] = null;
                Session["ModuleList"] = null;
                Alert.ShowInParent("授权成功");
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
            }
            catch (Exception ex)
            {
                Alert.ShowInParent(string.Format("错误信息：{0}", ex.Message));
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            var roleId = Request["id"];
            permissions = permissionDao.Entities.ToList();
            currentPermissions = roleDao.Entities.Where(m => m.Id == roleId).Select(m => m.Permissions).SingleOrDefault();
            GridBind();
        }
    }
}