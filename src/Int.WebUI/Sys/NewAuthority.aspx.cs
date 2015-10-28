using ENode.Commanding;
using FineUI;
using Int.AC.Commands.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Int.WebUI.Sys
{
    public partial class NewAuthority : BasePage
    {
        public ICommandService commandService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtModule.OnClientTriggerClick = wdnSelectModule.GetSaveStateReference(txtModule.ClientID, hiddenModuleID.ClientID)
                   + wdnSelectModule.GetShowReference("SelectModule.aspx?forpage=authority");
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                commandService.Send(new CreatePermission(txtCode.Text.Trim(), txtName.Text.Trim(), hiddenModuleID.Text));
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }

        protected void subwin_Close(object sender, WindowCloseEventArgs e)
        {
        }
    }
}