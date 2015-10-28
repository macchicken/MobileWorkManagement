using ENode.Commanding;
using FineUI;
using Int.AC.Commands.Services;
using Int.AC.ReadModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Int.WebUI.Sys
{
    public partial class NewService : BasePage
    {
        public ICommandService commandService { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var command = new CreateService(
                txtId.Text.Trim(), 
                txtName.Text.Trim(), 
                int.Parse(txtSort.Text.Trim()), 
                txtUrl.Text.Trim());
            try
            {
                commandService.Send(command);
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }
    }
}