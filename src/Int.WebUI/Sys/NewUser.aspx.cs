using ENode.Commanding;
using FineUI;
using Int.AC.Commands.Users;
using Int.AC.ReadModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Int.WebUI.Sys
{
    public partial class NewUser : BasePage
    {
        public ICommandService commandService { get; set; }
        public IUserDao userDao { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
                txtLeader.OnClientTriggerClick = selectLeaderWin.GetSaveStateReference(txtLeader.ClientID, hiddenLeader.ClientID)
                    + selectLeaderWin.GetShowReference("SelectUser.aspx");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                commandService.Send(new CreateUser(
                    txtCode.Text.Trim(),
                    txtName.Text.Trim(),
                    txtNameEn.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtPhone.Text.Trim(),
                    txtJob.Text.Trim(),
                    hiddenLeader.Text.Trim()
                ));
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
            }
            catch (Exception ex)
            {
                Alert.ShowInParent(string.Format("错误信息：{0}", ex.Message));
            }
        }
    }
}