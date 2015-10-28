using ENode.Commanding;
using FineUI;
using Int.AC.Commands.Menus;
using Int.AC.ReadModel.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Int.WebUI.Sys
{
    public partial class ModifyMenu : BasePage
    {
        public ICommandService commandService { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideReference();

                var list = permissionDao.Entities.Select(m => new { 
                    Id = m.Id,
                    Name = m.Module.Text + "("+ m.Name +")"
                }).ToList();
                ddlPermission.DataSource = list;
                ddlPermission.DataValueField = "Id";
                ddlPermission.DataTextField = "Name";
                ddlPermission.DataBind();
                ddlPermission.Items.Insert(0, new FineUI.ListItem("无需权限", ""));
                InitModule();
            }
        }

        protected void InitModule()
        {
            var id = Request["id"];
            var model = menuDao.Entities.Where(m => m.Id == id).SingleOrDefault();
            hiddenID.Text = model.Id.ToString();
            txtNavigateUrl.Text = model.NavigateUrl;
            txtSort.Text = model.Sort.ToString();
            hiddenParentID.Text = model.ParentId.ToString();
            if (!string.IsNullOrWhiteSpace(model.PermissionId))
            {
                ddlPermission.SelectedValue = model.PermissionId;
            }
            if (!string.IsNullOrWhiteSpace(model.ParentId))
            {
                var temp = menuDao.Entities.Where(m => m.Id == model.ParentId).Select(m => new { m.Text }).SingleOrDefault();
                txtParent.Text = temp.Text;
            }
            ddlMenuType.SelectedValue = ((int)model.MenuType).ToString();
            txtMobileUrl.Text = model.MobileUrl;
            txtText.Text = model.Text;
            chkUseAble.Checked = model.UseAble;
            txtParent.OnClientTriggerClick = wdnSelectMenu.GetSaveStateReference(txtParent.ClientID, hiddenParentID.ClientID)
                  + wdnSelectMenu.GetShowReference("SelectMenu.aspx?id=" + id);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                commandService.Send(new UpdateMenu(
                    hiddenID.Text,
                    txtText.Text.Trim(),
                    int.Parse(ddlMenuType.SelectedValue),
                    txtNavigateUrl.Text.Trim(),
                    txtMobileUrl.Text.Trim(),
                    hiddenParentID.Text,
                    int.Parse(txtSort.Text),
                    ddlPermission.SelectedValue,
                    chkUseAble.Checked
                ));
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }
    }
}
