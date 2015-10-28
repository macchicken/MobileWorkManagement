using ENode.Commanding;
using FineUI;
using Int.AC.Commands.Users;
using Int.AC.ReadModel.Departments;
using Int.AC.ReadModel.Users;
using Int.Common;
using LinqToExcel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Int.WebUI.Sys
{
    public partial class UserList : BasePage
    {
        public ICommandService commandService { get; set; }

        public DepartmentDao departmentDao { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridBind();

                btnAdd.OnClientClick = newUserWin.GetShowReference();
                btnModify.OnClientClick = userGrid.GetNoSelectionAlertReference(string.Format("请选择要编辑的{0}！", userGrid.Title));
                btnRole.OnClientClick = userGrid.GetNoSelectionAlertReference(string.Format("请选择要授权的{0}！", userGrid.Title));
                btnChangePwd.OnClientClick = userGrid.GetNoSelectionAlertReference(string.Format("请选择要修改的{0}！", userGrid.Title));
            }
        }

        protected void btnRole_Click(object sender, EventArgs e)
        {
            awardRoleWin.IFrameUrl = string.Format("AwardRole.aspx?id={0}", userGrid.DataKeys[userGrid.SelectedRowIndex][0]);
            awardRoleWin.Hidden = false;
            awardRoleWin.Title = string.Format("授权-{0}", userGrid.DataKeys[userGrid.SelectedRowIndex][1]);
        }

        protected void btnChangePwd_Click(object sender, EventArgs e)
        {
            ChangePwdWin.IFrameUrl = string.Format("ChangePwd.aspx?id={0}", userGrid.DataKeys[userGrid.SelectedRowIndex][0]);
            ChangePwdWin.Hidden = false;
            ChangePwdWin.Title = string.Format("修改密码-{0}", userGrid.DataKeys[userGrid.SelectedRowIndex][1]);
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            modifyUserWin.IFrameUrl = string.Format("ModifyUser.aspx?id={0}", userGrid.DataKeys[userGrid.SelectedRowIndex][0]);
            modifyUserWin.Hidden = false;
        }

        private void GridBind()
        {
            var query = userDao.Entities;
            if (!string.IsNullOrWhiteSpace(ttbSearch.Text.Trim()))
            {
                query = query.Where(m => m.Code.Contains(ttbSearch.Text.Trim()));
            }
            var list = query.OrderBy(m => m.CreatedOn).Skip((userGrid.PageIndex) * userGrid.PageSize).Take(userGrid.PageSize).Select(m => new
            {
                Id = m.Id,
                Code = m.Code,
                Name = m.Name,
                NameEn = m.NameEn,
                JobName = m.JobName,
                Phone = m.Phone,
                Email = m.Email,
                LeaderName = m.Leader.Name,
                UseAble = m.UseAble
            }).ToList();
            userGrid.RecordCount = query.Count();
            userGrid.DataSource = list;
            userGrid.DataBind();
        }

        /// <summary>
        /// 清空查询条件
        /// </summary>
        protected void ttbSearch_Trigger1Click(object sender, EventArgs e)
        {
            ttbSearch.Text = String.Empty;
            ttbSearch.ShowTrigger1 = false;
            this.userGrid.PageIndex = 0;
            GridBind();
        }

        protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
        {
            this.userGrid.PageIndex = 0;
            ttbSearch.ShowTrigger1 = true;
            GridBind();
        }

        /// <summary>
        /// 数据分页
        /// </summary>
        protected void userGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            this.userGrid.PageIndex = e.NewPageIndex;
            GridBind();
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpload_FileSelected(object sender, EventArgs e)
        {
            if (btnUpload.HasFile)
            {
                string fileName = btnUpload.ShortFileName;
                if (!fileName.EndsWith(".xlsx"))
                {
                    Alert.Show("只支持xlsx文件类型！");
                    return;
                }
                string path = ConfigHelper.GetStringProperty("DataFilePath", @"D:\root\Int\data\") + "tmp\\" + fileName;
                btnUpload.SaveAs(path);
                var execelfile = new ExcelQueryFactory(path);
                execelfile.AddMapping<UserInfo>(x => x.Code, "登录帐号");
                execelfile.AddMapping<UserInfo>(x => x.Name, "姓名");
                execelfile.AddMapping<UserInfo>(x => x.NameEn, "英文名");
                execelfile.AddMapping<UserInfo>(x => x.Departments, "部门");
                execelfile.AddMapping<UserInfo>(x => x.JobName, "职位");
                execelfile.AddMapping<UserInfo>(x => x.Phone, "电话");
                execelfile.AddMapping<UserInfo>(x => x.Email, "电子邮箱");
                execelfile.AddMapping<UserInfo>(x => x.LeaderCode, "上级领导");
                var list = execelfile.Worksheet<UserInfo>(0).ToList();
                Import(list);
                this.userGrid.PageIndex = 0;
                GridBind();
                Alert.Show("上传成功");
            }
        }

        protected void subwin_Close(object sender, WindowCloseEventArgs e)
        {
            GridBind();
        }

        private void Import(List<UserInfo> list)
        {
            string resultMsg = string.Empty;
            var departments = departmentDao.Entities.ToList();
            var users = userDao.Entities.ToList();
            User form;
            var i = 1;
            foreach (var item in list)
            {
                form = users.Where(m => m.Code == item.Code).FirstOrDefault();
                if (form == null)
                {
                    form = new User();
                }
                form.Code = item.Code.Trim();
                form.Departments = new List<Department>();
                form.Email = item.Email;
                form.JobName = item.JobName;
                if (!string.IsNullOrWhiteSpace(item.LeaderCode))
                    form.LeaderId = users.Where(m => m.Code == item.LeaderCode.Trim()).FirstOrDefault().Id;
                form.Name = item.Name.Trim();
                form.NameEn = item.NameEn.Trim();
                form.Phone = item.Phone;
                if(string.IsNullOrWhiteSpace(form.Id))
                {
                    commandService.Send(new CreateUser(
                        form.Code,
                        form.Name,
                        form.NameEn,
                        form.Email,
                        form.Phone,
                        form.JobName,
                        form.LeaderId,
                        string.IsNullOrWhiteSpace(item.Departments.Trim()) ? null : item.Departments.Trim().Split(',')
                    ));
                }
                else
                {
                    commandService.Send(new UpdateUser(
                        form.Id,
                        form.Code,
                        form.Name,
                        form.NameEn,
                        form.Email,
                        form.Phone,
                        form.JobName,
                        form.LeaderId,
                        form.UseAble,
                        string.IsNullOrWhiteSpace(item.Departments.Trim()) ? null : item.Departments.Trim().Split(',')
                    )); 
                }
                users.Add(form);
            }
        }
    }
}