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
    public partial class ModifyUser : BasePage
    {
        public ICommandService commandService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
                txtLeader.OnClientTriggerClick = selectLeaderWin.GetSaveStateReference(txtLeader.ClientID, hiddenLeader.ClientID)
                    + selectLeaderWin.GetShowReference("SelectUser.aspx");
                InitModule();
            }
        }

        private void InitModule()
        {
            if (Request["ID"] == null || Request["ID"] == "0")
                return;

            var id = Request["ID"].ToString();
            hiddenID.Text = id.ToString();
            var model = userDao.Entities.Where(m => m.Id == id).Select(m => new
            {
                m.Code,
                m.Email,
                m.Phone,
                m.Name,
                m.JobName,
                m.LeaderId,
                LeaderName = m.Leader.Name,
                m.NameEn,
                m.UseAble
            }).SingleOrDefault();
            txtCode.Text = model.Code;
            txtEmail.Text = model.Email;
            txtPhone.Text = model.Phone;
            txtName.Text = model.Name;
            txtNameEn.Text = model.NameEn;
            txtJob.Text = model.JobName;
            hiddenLeader.Text = model.LeaderId.ToString();
            chkUseAble.Checked = model.UseAble;
            txtLeader.Text = model.LeaderName;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                commandService.Send(new UpdateUser(
                    hiddenID.Text,
                    txtCode.Text.Trim(),
                    txtName.Text.Trim(),
                    txtNameEn.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtPhone.Text.Trim(),
                    txtJob.Text.Trim(),
                    hiddenLeader.Text.Trim(),
                    chkUseAble.Checked
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