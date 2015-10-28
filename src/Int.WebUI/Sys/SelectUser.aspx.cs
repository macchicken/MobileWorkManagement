using FineUI;
using Int.AC.ReadModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Int.WebUI.Sys
{
    public partial class SelectUser : BasePage
    {
        public IUserDao userDao { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridBind();
            }
        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            string id = "";
            string name = "";
            if (userGrid.SelectedRowIndex > -1)
            {
                List<object[]> ids = userGrid.DataKeys;
                object[] obj = ids[userGrid.SelectedRowIndex];
                id = obj == null ? "" : obj[0].ToString();
                name = obj == null ? "" : obj[1].ToString();
            }

            PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(name, id)
                + ActiveWindow.GetHidePostBackReference("param_from_selected"));
        }

        private void GridBind()
        {
            userGrid.DataSource = userDao.Entities.ToList();
            userGrid.DataBind();
        }
    }
}