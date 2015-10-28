using FineUI;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Int.AC.ReadModel.Roles;
using Int.AC.ReadModel.Users;

namespace Int.WebUI.Sys
{
    public partial class RoleUser : BasePage
    {
        public IRoleDao roleDao { get; set; }
        public IUserDao userDao { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridBind();
                RightBind();
            }
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
            }).ToList();
            userGrid.RecordCount = query.Count();
            userGrid.DataSource = list;
            userGrid.DataBind();
        }

        private void RightBind()
        {
            var id = Request["id"];
            var users = roleDao.Entities.Include(m => m.Users).Where(m => m.Id == id).Select(m => m.Users).SingleOrDefault();
            rightGrid.DataSource = users;
            rightGrid.DataBind();
        }

        protected void userGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            this.userGrid.PageIndex = e.NewPageIndex;
            GridBind();
        }


        protected void btnEnter_Click(object sender, EventArgs e)
        {
            //var id = Guid.Parse(Request["id"]);
            //List<object[]> selecteds = rightGrid.DataKeys;
            //Guid[] ids = new Guid[selecteds.Count()];
            //for (int i = 0; i < selecteds.Count; i++)
            //{
            //    ids[i] = Guid.Parse(selecteds[i][0].ToString());
            //}
            //try
            //{
            //    roleDao.SetUsers(id, ids);
            //    PageContext.RegisterStartupScript(ActiveWindow.GetHideReference());
            //}
            //catch (Exception ex)
            //{
            //    Alert.ShowInParent(string.Format("错误信息：{0}", ex.Message));
            //}
        }

        /// <summary>
        /// 右移
        /// </summary>
        protected void btnRight_Click(object sender, EventArgs e)
        {
            var userList = new List<User>();
            int[] keys = userGrid.SelectedRowIndexArray;
            List<object[]> list = new List<object[]>();
            for (int i = 0; i < keys.Length; i++)
            {
                list.Add(userGrid.DataKeys[keys[i]]);
            }
            List<object[]> selected = rightGrid.DataKeys;
            for (int i = 0; i < selected.Count; i++)
            {
                userList.Add(new User
                {
                    Id = selected[i][0].ToString(),
                    Name = selected[i][1].ToString(),
                    Code = selected[i][2].ToString()
                });
            }

            #region 判断右边的Grid是否已含员工信息
            for (int i = 0; i < list.Count; i++)
            {
                bool contains = false;
                for (int j = 0; j < selected.Count; j++)
                {
                    if (list[i][0].Equals(selected[j][0]))
                    {
                        contains = true;
                        break;
                    }
                }
                if (!contains)
                {
                    var user = new User
                    {
                        Id = list[i][0].ToString(),
                        Name = list[i][1].ToString(),
                        Code = list[i][2].ToString()
                    };
                    userList.Add(user);
                }
            }
            #endregion

            rightGrid.DataSource = userList;
            rightGrid.DataBind();
        }

        protected void btnLeft_Click(object sender, EventArgs e)
        {
            List<User> userList = new List<User>();
            List<object[]> selected = rightGrid.DataKeys;
            for (int i = 0; i < selected.Count; i++)
            {
                userList.Add(new User
                {
                    Id = selected[i][0].ToString(),
                    Name = selected[i][1].ToString(),
                    Code = selected[i][2].ToString()
                });
            }

            int[] keys = rightGrid.SelectedRowIndexArray;
            List<string> list = new List<string>();
            for (int i = 0; i < keys.Length; i++)
            {
                list.Add(rightGrid.DataKeys[keys[i]][0].ToString());
            }
            for (int i = 0; i < list.Count; i++)
            {
                userList.Remove(userList.Where(d => d.Id == list[i]).FirstOrDefault());
            }
            rightGrid.DataSource = userList;
            rightGrid.DataBind();
        }

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

        protected void userGrid_RowDoubleClick(object sender, GridRowClickEventArgs e)
        {
            btnRight_Click(null, null);
        }

        protected void rightGrid_RowDoubleClick(object sender, GridRowClickEventArgs e)
        {
            btnLeft_Click(null, null);
        }
    }
}