using FineUI;
using Int.AC.ReadModel.Departments;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Int.WebUI.Sys
{
    public partial class DepartmentList : BasePage
    {
        public DepartmentDao departmentDao { get; set; }
        List<Department> moduleList = new List<Department>();
        List<Department> treeList = new List<Department>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridBind();

                btnNew.OnClientClick = newDepartmentWin.GetShowReference();
                btnModify.OnClientClick = departmentGrid.GetNoSelectionAlertReference(string.Format("请选择要编辑的{0}！", departmentGrid.Title));
                btnDepartmentUser.OnClientClick = departmentGrid.GetNoSelectionAlertReference(string.Format("请选择要编辑的{0}！", departmentGrid.Title));
            }
        }
        private void GridBind()
        {
            moduleList = departmentDao.Entities.Include(m => m.Users).ToList();
            departmentGrid.DataSource = BuildTree();
            departmentGrid.DataBind();
        }

        /// <summary>
        /// 删除事件
        /// </summary>
        protected void departmentGrid_RowCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "delete")
                {
                    //object[] keys = departmentGrid.DataKeys[e.RowIndex];
                    //var id = int.Parse(keys[0].ToString());
                    //var model = departmentApp.Entities.Where(m => m.Id == id).Select(m => new { UserCount = m.Users.Count() }).SingleOrDefault();
                    //if (model == null)
                    //{
                    //    Alert.ShowInParent("您要删除的部门不存在。");
                    //    return;
                    //}
                    //if (model.UserCount > 0)
                    //{
                    //    Alert.ShowInParent("存在关联的员工，删除失败。");
                    //    return;
                    //}
                    //if (departmentApp.Entities.Where(m => m.ParentId == id).Count() > 0)
                    //{
                    //    Alert.ShowInParent("存在关联的子部门，删除失败。");
                    //    return;
                    //}
                    //var form = departmentApp.Entities.Where(m => m.Id == id).SingleOrDefault();
                    //departmentApp.AutoDetectChangesEnabled = true;
                    //form.IsDeleted = true;
                    //departmentApp.SaveDepartment(form);
                    //GridBind();
                }
            }
            catch (Exception ex)
            {
                Alert.ShowInParent(ex.Message);
            }
        }

        protected void departmentGrid_RowDataBound(object sender, FineUI.GridRowEventArgs e)
        {
            var rptUser = departmentGrid.Rows[e.RowIndex].FindControl("rptUser") as System.Web.UI.WebControls.Repeater;
            dynamic row = e.DataItem as dynamic;
            if (row != null)
            {
                rptUser.DataSource = row.Users;
                rptUser.DataBind();
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            modifyDepartmentWin.IFrameUrl = string.Format("ModifyDepartment.aspx?id={0}", departmentGrid.DataKeys[departmentGrid.SelectedRowIndex][0]);
            modifyDepartmentWin.Hidden = false;
        }

        protected void btnDepartmentUser_Click(object sender, EventArgs e)
        {
            viewUserWin.IFrameUrl = string.Format("DepartmentUser.aspx?id={0}", departmentGrid.DataKeys[departmentGrid.SelectedRowIndex][0]);
            viewUserWin.Hidden = false;
        }


        private List<Department> BuildTree()
        {
            List<Department> tempList = moduleList.Where(s => s.ParentId == null).OrderBy(m => m.Id).ToList();
            foreach (var a in tempList)
            {
                a.TreeLevel = 1;
                treeList.Add(a);
                BuildSubTree(a, 1);
            }
            return treeList;
        }

        private void BuildSubTree(Department model, int level)
        {
            var tempList = moduleList.Where(s => s.ParentId == model.Id).OrderBy(m => m.Id).ToList();
            level++;
            foreach (var a in tempList)
            {
                a.TreeLevel = level;
                treeList.Add(a);
                BuildSubTree(a, level);
            }
        }

        protected void subwin_Close(object sender, WindowCloseEventArgs e)
        {
            GridBind();
        }

        protected void departmentGrid_RowDoubleClick(object sender, GridRowClickEventArgs e)
        {
            if (btnModify.Enabled)
                btnModify_Click(null, null);
        }
    }
}