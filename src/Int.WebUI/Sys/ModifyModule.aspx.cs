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
    public partial class ModifyModule : BasePage
    {
        public ICommandService commandService { get; set; }
        public IServiceDao serviceDao { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                InitModule();
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
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

        protected void InitModule()
        {
            var id = Request["id"];
            var model = moduleDao.Entities.Where(m => m.Id == id).SingleOrDefault();
            hiddenID.Text = model.Id.ToString();
            txtCode.Text = model.Code;
            txtSort.Text = model.Sort.ToString();
            hiddenParentID.Text = model.ParentId.ToString();
            ddlService.SelectedValue = model.ServiceId;
            if (!string.IsNullOrWhiteSpace(model.ParentId))
            {
                var temp = moduleDao.Entities.Where(m => m.Id == model.ParentId).Select(m => new { Text = m.Text }).SingleOrDefault();
                txtParent.Text = temp.Text;
            }
            txtText.Text = model.Text;
            chkUseAble.Checked = model.UseAble;
            txtParent.OnClientTriggerClick = wdnSelectModule.GetSaveStateReference(txtParent.ClientID, hiddenParentID.ClientID)
                  + wdnSelectModule.GetShowReference("SelectModule.aspx?id=" + id);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                commandService.Send(new UpdateModule(
                    hiddenID.Text,
                    txtCode.Text,
                    txtText.Text.Trim(),
                    hiddenParentID.Text,
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