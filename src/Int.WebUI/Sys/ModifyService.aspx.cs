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
    public partial class ModifyService : BasePage
    {
        public ICommandService commandService { get; set; }
        public IServiceDao serviceDao { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
                LoadData();
            }
        }

        private void LoadData()
        {
            if (Request["ID"] == null || Request["ID"] == "0")
                return;

            var id = Request["ID"].ToString();
            var model = serviceDao.Entities.Where(m => m.Id == id).SingleOrDefault();
            txtId.Text = model.Id;
            txtName.Text = model.Name;
            txtSort.Text = model.Sort.ToString();
            txtUrl.Text = model.Url;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                commandService.Send(new UpdateService(
                    txtId.Text,
                    txtName.Text.Trim(),
                    int.Parse(txtSort.Text),
                    txtUrl.Text.Trim()
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