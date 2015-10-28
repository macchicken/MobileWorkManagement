using ENode.Commanding;
using FineUI;
using Int.AC.Commands.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Int.WebUI.Sys
{
    public partial class NewDepartment : BasePage
    {
        public ICommandService commandService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
                txtParent.OnClientTriggerClick = selectDepartmentWin.GetSaveStateReference(txtParent.ClientID, hiddenParentID.ClientID)
                     + selectDepartmentWin.GetShowReference("SelectDepartment.aspx?ID=" + hiddenParentID.Text);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                commandService.Send(new CreateDepartment(txtId.Text, txtName.Text.Trim(), hiddenParentID.Text));
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
            }
            catch (Exception ex)
            {
                Alert.ShowInParent(ex.Message);
            }
        }

        protected void subwin_Close(object sender, WindowCloseEventArgs e)
        {

        }
    }
}