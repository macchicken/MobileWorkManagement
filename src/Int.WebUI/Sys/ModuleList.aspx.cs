using FineUI;
using Int.AC.ReadModel.Modules;
using Int.AC.ReadModel.Permissions;
using Int.AC.ReadModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Int.WebUI.Sys
{
    public partial class ModuleList : BasePage
    {
        List<Module> moduleList = new List<Module>();
        List<Module> treeList = new List<Module>();
        List<Permission> permissions = new List<Permission>();
        public IServiceDao serviceDao { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                permissions = permissionDao.Entities.ToList();
                LoadData();
                GridBind();
                btnNew.OnClientClick = newModuleWin.GetShowReference();
                btnModify.OnClientClick =moduleGrid.GetNoSelectionAlertReference(string.Format("请选择要操作的{0}！", this.moduleGrid.Title));
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

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void GridBind()
        {
            var serviceId = ddlService.SelectedValue;
            moduleList = moduleDao.Entities.Where(m=>m.ServiceId == serviceId).ToList();
            moduleGrid.DataSource = BuildTree();
            moduleGrid.DataBind();
        }

        private List<Module> BuildTree()
        {
            List<Module> tempList = moduleList.Where(s => s.ParentId == null).OrderBy(m => m.Sort).ToList();
            foreach (var a in tempList)
            {
                a.TreeLevel = 1;
                treeList.Add(a);
                BuildSubTree(a, 1);
            }
            return treeList;
        }

        private void BuildSubTree(Module model, int level)
        {
            var tempList = moduleList.Where(s => s.ParentId == model.Id).OrderBy(m => m.Sort).ToList();
            level++;
            foreach (var a in tempList)
            {
                a.TreeLevel = level;
                treeList.Add(a);
                BuildSubTree(a, level);
            }
        }

        StringBuilder sb;
        protected void moduleGrid_RowDataBound(object sender, FineUI.GridRowEventArgs e)
        {
            var lbAuthority = moduleGrid.Rows[e.RowIndex].FindControl("lbAuthority") as System.Web.UI.WebControls.Literal;
            dynamic row = e.DataItem as dynamic;
            if (row != null)
            {
                sb = new StringBuilder();
                var id = row.Id;
                var list = permissions.Where(m => m.ModuleId == id).ToList();
                foreach (var item in list)
                {
                    sb.Append(item.Name + ",");
                }
                if (sb.Length > 0)
                {
                    lbAuthority.Text = sb.ToString().TrimEnd(',');
                }
            }
        }

        /// <summary>
        /// 删除事件
        /// </summary>
        protected void moduleGrid_RowCommand(object sender, GridCommandEventArgs e)
        {
            //if (e.CommandName == "delete")
            //{
            //    try
            //    {
            //        object[] keys = moduleGrid.DataKeys[e.RowIndex];
            //        var id = int.Parse(keys[0].ToString());
            //        var form = moduleApp.Entities.Where(m => m.Id == id).SingleOrDefault();
            //        moduleApp.AutoDetectChangesEnabled = true;
            //        form.IsDeleted = true;
            //        moduleApp.SaveModule(form);
            //        GridBind();
            //    }
            //    catch (Exception ex)
            //    {
            //        Alert.Show(ex.Message);
            //    }
            //}
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            modifyModuleWin.IFrameUrl = string.Format("ModifyModule.aspx?id={0}", moduleGrid.DataKeys[moduleGrid.SelectedRowIndex][0]);
            modifyModuleWin.Hidden = false;
        }

        protected void subwin_Close(object sender, WindowCloseEventArgs e)
        {
            permissions = permissionDao.Entities.ToList();
            GridBind();
        }

        protected void ddlService_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridBind();
        }
    }
}