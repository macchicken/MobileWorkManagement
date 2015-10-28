using ENode.Commanding;
using FineUI;
using Int.AC.Commands.Users;
using Int.AC.ReadModel.Roles;
using Int.AC.ReadModel.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Int.WebUI.Sys
{
    public partial class AwardRole : BasePage
    {
        public ICommandService commandService { get; set; }
        public IRoleDao roleDao { get; set; }
        public IUserDao userDao { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();

                var list = roleDao.Entities.ToList();
                chkRole.DataSource = list;
                chkRole.DataTextField = "Name";
                chkRole.DataValueField = "Id";
                chkRole.DataBind();

                InitModule();
            }
        }

        private void InitModule()
        {
            var id = Request["id"];
            hiddenID.Text = id.ToString();

            var roles = userDao.Entities.Include(m => m.Roles).Where(m => m.Id == id).Select(m => m.Roles).SingleOrDefault();
            string[] selectArray = new string[roles.Count()];
            for (int i = 0; i < roles.Count(); i++)
            {
                selectArray[i] = roles[i].Id.ToString();
            }
            chkRole.SelectedValueArray = selectArray;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var id = Request["id"];
            string[] strIDs = chkRole.SelectedValueArray;
            string[] roleIds = new string[strIDs.Length];
            for (int i = 0; i < strIDs.Length; i++)
			{
                roleIds[i] = strIDs[i];
			} 
            try
            {
                commandService.Send(new SetUserRoles(id, roleIds));
                Session["MenuList"] = null;
                Session["AuthorityList"] = null;
                PageContext.RegisterStartupScript(ActiveWindow.GetHideReference());
            }
            catch (Exception ex)
            {
                Alert.ShowInParent(string.Format("错误信息：{0}", ex.Message));
            }
        }
    }
}