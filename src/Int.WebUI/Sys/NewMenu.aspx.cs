using ENode.Commanding;
using FineUI;
using Int.AC.Commands.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Int.WebUI.Sys
{
    public partial class NewMenu : BasePage
    {
        public ICommandService commandService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtParent.OnClientTriggerClick = wdnSelectMenu.GetSaveStateReference(txtParent.ClientID, hiddenParentID.ClientID)
                   + wdnSelectMenu.GetShowReference("SelectMenu.aspx");
                btnClose.OnClientClick = ActiveWindow.GetHideReference();

                var list = permissionDao.Entities.Select(m => new
                {
                    Id = m.Id,
                    Name = m.Module.Text + "(" + m.Name + ")"
                }).ToList();
                ddlPermission.DataSource = list;
                ddlPermission.DataValueField = "Id";
                ddlPermission.DataTextField = "Name";
                ddlPermission.DataBind();
                ddlPermission.Items.Insert(0, new FineUI.ListItem("无需权限", ""));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                commandService.Send(new CreateMenu(
                    txtText.Text.Trim(),
                    int.Parse(ddlMenuType.SelectedValue),
                    txtNavigateUrl.Text.Trim(),
                    txtMobileUrl.Text.Trim(),
                    int.Parse(txtSort.Text),
                    hiddenParentID.Text,
                    ddlPermission.SelectedValue
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