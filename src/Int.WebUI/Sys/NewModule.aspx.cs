using ENode.Commanding;
using FineUI;
using Int.AC.Commands.Modules;
using Int.AC.ReadModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Int.WebUI.Sys
{
    public partial class NewModule : BasePage
    {
        public ICommandService commandService { get; set; }
        public IServiceDao serviceDao { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtParent.OnClientTriggerClick = wdnSelectModule.GetSaveStateReference(txtParent.ClientID, hiddenParentID.ClientID)
                   + wdnSelectModule.GetShowReference("SelectModule.aspx");
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
                LoadData();
            }
        }

        private void LoadData()
        {
            ddlService.DataSource = serviceDao.Entities.OrderBy(m => m.Sort).ToList();
            ddlService.DataTextField = "Name";
            ddlService.DataValueField = "Id";
            ddlService.DataBind();
            ddlService.SelectedIndex = 0;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                commandService.Send(new CreateModule(
                    txtCode.Text,
                    txtText.Text.Trim(),
                    hiddenParentID.Text,
                    int.Parse(txtSort.Text)
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