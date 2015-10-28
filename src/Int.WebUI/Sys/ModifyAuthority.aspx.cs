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
    public partial class ModifyAuthority : BasePage
    {
        public ICommandService commandService { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtModule.OnClientTriggerClick = wdnSelectMenu.GetSaveStateReference(txtModule.ClientID, hiddenModuleID.ClientID)
                   + wdnSelectMenu.GetShowReference("SelectMenu.aspx?forpage=authority");
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
                InitModule();
            }
        }

        private void InitModule()
        {
            var id = Request["id"];
            var model = permissionDao.Entities.Where(m => m.Id == id).Select(m => new
            { 
                Id = m.Id,
                Code = m.Code,
                Name = m.Name,
                ModuleText = m.Module.Text,
                ModuleId = m.ModuleId
            }).SingleOrDefault();
            txtCode.Text = model.Code;
            txtName.Text = model.Name;
            txtModule.Text = model.ModuleText;
            hiddenModuleID.Text = model.ModuleId.ToString();
            hiddenID.Text = id.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                commandService.Send(new UpdatePermission(
                    hiddenID.Text,
                    txtCode.Text.Trim(),
                    txtName.Text.Trim(),
                    txtName.Text.Trim()
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