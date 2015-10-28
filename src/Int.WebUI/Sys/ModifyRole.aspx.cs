using ENode.Commanding;
using FineUI;
using Int.AC.Commands.Roles;
using Int.AC.ReadModel.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Int.WebUI.Sys
{
    public partial class ModifyRole : BasePage
    {
        public ICommandService commandService { get; set; }
        public IRoleDao roleDao { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitModule();
                btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
            }
        }

        private void InitModule()
        {
            var id = Request["id"];
            var model = roleDao.Entities.Where(m => m.Id == id).SingleOrDefault();
            hiddenID.Text = id.ToString();
            txtSort.Text = model.Sort.ToString();
            txtName.Text = model.Name;
            chkUseAble.Checked = model.UseAble;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                commandService.Send(new UpdateRole(
                    hiddenID.Text,
                    txtName.Text.Trim(),
                    int.Parse(txtSort.Text),
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