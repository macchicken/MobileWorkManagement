using ENode.Commanding;
using FineUI;
using Int.AC.ReadModel.Users;
using Int.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Int.WebUI.Sys
{
    public partial class ChangePwd : BasePage
    {
        public ICommandService commandService { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
                var id = Guid.Parse(Request["id"]);
                hiddenID.Text = id.ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                commandService.Send(new Int.AC.Commands.Users.ChangePassword(hiddenID.Text, Utility.EncryptPwd(txtPassword1.Text)));
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }
    }
}