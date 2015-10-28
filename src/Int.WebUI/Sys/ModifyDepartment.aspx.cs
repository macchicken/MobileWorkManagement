using ENode.Commanding;
using FineUI;
using Int.AC.Commands.Departments;
using Int.AC.ReadModel.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Int.WebUI.Sys
{
    public partial class ModifyDepartment : BasePage
    {
        public ICommandService commandService { get; set; }
        public IDepartmentDao departmentDao { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
                txtParent.OnClientTriggerClick = selectDepartmentWin.GetSaveStateReference(txtParent.ClientID, hiddenParentID.ClientID)
                     + selectDepartmentWin.GetShowReference("SelectDepartment.aspx?ID=" + hiddenParentID.Text);
                LoadData();
            }
        }

        private void LoadData()
        {
            if (Request["ID"] == null || Request["ID"] == "0")
                return;

            var id = Request["ID"].ToString();
            txtID.Text = id;
            var model = departmentDao.Entities.Where(m => m.Id == id).Select(m => new
            {
                m.Id,
                m.Name,
                m.ParentId,
                ParentName = m.Parent.Name
            }).SingleOrDefault();
            txtName.Text = model.Name;
            if (!string.IsNullOrWhiteSpace(model.ParentId))
            {
                hiddenParentID.Text = model.ParentId.ToString();
                txtParent.Text = model.ParentName;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                commandService.Send(new UpdateDepartment(
                    txtID.Text,
                    txtName.Text.Trim(),
                    hiddenParentID.Text
                ));
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
            }
            catch (Exception ex)
            {
                Alert.ShowInParent(ex.Message);
            }
        }
    }
}