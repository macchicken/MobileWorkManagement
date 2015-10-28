using FineUI;
using Int.AC.ReadModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Int.WebUI.Sys
{
    public partial class ServiceList : BasePage
    {
        public IServiceDao serviceDao { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridBind();

                btnNew.OnClientClick = newServiceWin.GetShowReference();
                btnModify.OnClientClick = serviceGrid.GetNoSelectionAlertReference(string.Format("请选择要编辑的{0}！", serviceGrid.Title));
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            modifyServiceWin.IFrameUrl = string.Format("ModifyService.aspx?id={0}", serviceGrid.DataKeys[serviceGrid.SelectedRowIndex][0]);
            modifyServiceWin.Hidden = false;
        }

        private void GridBind()
        {
            var list = serviceDao.Entities.OrderBy(m => m.Sort).ToList();
            serviceGrid.DataSource = list;
            serviceGrid.DataBind();
        }

        protected void subwin_Close(object sender, WindowCloseEventArgs e)
        {
            GridBind();
        }

        protected void serviceGrid_RowDoubleClick(object sender, GridRowClickEventArgs e)
        {
            if(btnModify.Enabled)
                btnModify_Click(null, null);
        }
    }
}