using FineUI;
using Int.AC.ReadModel.Menus;
using Int.AC.ReadModel.Modules;
using Int.AC.ReadModel.Permissions;
using Int.AC.ReadModel.Users;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Int.WebUI
{
    public class BasePage : System.Web.UI.Page
    {
        public IModuleDao moduleDao { get; set; }
        public IMenuDao menuDao { get; set; }
        public IPermissionDao permissionDao { get; set; }
        public IUserDao userDao { get; set; }

        #region 当前用户信息
        public string UserId
        {
            get
            {
                if (Session["UserId"] == null || Session["UserId"].ToString() == string.Empty)
                {
                    var user = userDao.Entities.Where(m => m.Code == "sysadmin").SingleOrDefault();
                    Session["UserName"] = user.Name;
                    return user.Id;
                }
                return Session["UserId"].ToString();
            }
        }
        public string PersonnelName
        {
            get
            {
                if (UserId == string.Empty)
                    return string.Empty;
                return Session["UserName"].ToString();
            }
        }
        public int DepartmentId
        {
            get
            {
                if (Session["DepartmentId"] == null)
                    return 0;
                return int.Parse(Session["DepartmentId"].ToString());
            }
        }

        public bool IsAdmin
        {
            get
            {
                if (Session["IsAdmin"] == null || Session["IsAdmin"].ToString() == string.Empty)
                    return false;
                return bool.Parse(Session["IsAdmin"].ToString());
            }
        }
        #endregion

        #region 页面初始化

        List<string> controlList = new List<string>();
        Module currentModule = new Module();
        protected override void OnInit(EventArgs e)
        {
            if (UserId == string.Empty)
            {
                Response.Redirect("~/Default.aspx");
            }
            CheckPermission();
            base.OnInit(e);
        }

        protected virtual void CheckPermission()
        {
            if (this.Form != null && this.Form.Name != "mainForm")
            {
                string code = this.Form.ID.Substring(3);
                WebPageAuthority webPageAuthority = this.FindControl("pageAuthority") as WebPageAuthority;
                if (webPageAuthority != null)
                {
                    currentModule = this.ModuleList.Where(m => m.Code == code).SingleOrDefault();
                    controlList = this.JsonToList<string>(webPageAuthority.PageAuthority);
                    CheckPowerEdit(this.Form.Controls);
                }
                else
                {
                    if (code != "NotNeedCheck")
                    {
                        var currentPermission = this.PermissionList.Where(m => m.Code == code).SingleOrDefault();
                        if (currentPermission == null)
                            PageContext.Redirect("/Error.aspx?fromUrl=" + Request.Url.AbsolutePath + "&message=" + Server.UrlDecode("您没有该页面的访问权限"));
                    }
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        /// <summary>
        /// 获取当前页面上所有的权限按钮
        /// </summary>
        private void CheckPowerEdit(ControlCollection controls)
        {
            for (int i = 0; i < controls.Count; i++)
            {
                ControlBase ctrl = controls[i] as ControlBase;
                if (ctrl == null)
                    continue;

                string codeExt = string.Empty;
                if (ctrl is FineUI.Grid)
                {
                    #region Grid的权限控制
                    FineUI.Grid grid = ctrl as FineUI.Grid;
                    foreach (GridColumn column in grid.Columns)
                    {
                        if (!controlList.Contains(column.ColumnID))
                            continue;

                        codeExt = column.ColumnID.Substring(3);
                        var auth = PermissionList.Where(m => m.ModuleId == currentModule.Id && m.Code.StartsWith(codeExt)).SingleOrDefault();
                        if (auth == null)
                        {
                            if (column is LinkButtonField)
                            {
                                LinkButtonField c = (LinkButtonField)column;
                                //c.Enabled = false;
                                //c.ToolTip = "您没有权限，请联系管理员";
                                c.Hidden = true;
                            }
                            else if (column is WindowField)
                            {
                                WindowField c = (WindowField)column;
                                //c.Enabled = false;
                                //c.ToolTip = "您没有权限，请联系管理员";
                                c.Hidden = true;
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    #region 其他控件的权限控制
                    if (controlList.Contains(ctrl.ID) && !IsPostBack)
                    {
                        codeExt = ctrl.ID.Substring(3);
                        var auth = PermissionList.Where(m => m.ModuleId == currentModule.Id && m.Code.StartsWith(codeExt)).SingleOrDefault();
                        if (auth == null)
                        {
                            //ctrl.Enabled = false;
                            ctrl.Visible = false;
                        }
                    }
                    CheckPowerEdit(ctrl.Controls);
                    #endregion
                }
            }
        }

        #endregion

        #region 页面的公共方法

        /// <summary>
        /// Json转字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public List<T> JsonToList<T>(string str)
        {
            JArray idsArray = new JArray();
            if (!String.IsNullOrEmpty(str))
                idsArray = JArray.Parse(str);
            return new List<T>(idsArray.ToObject<List<T>>());
        }

        /// <summary>
        /// List<string>转Json字符串
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public string ListToJson<T>(List<T> ids)
        {
            return new JArray(ids).ToString(Newtonsoft.Json.Formatting.None);
        }

        /// <summary>
        /// json转byte
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public byte[] JsonTobyte(string str)
        {
            JArray idsArray = new JArray();
            if (!String.IsNullOrEmpty(str))
                idsArray = JArray.Parse(str);
            List<byte> list = idsArray.ToObject<List<byte>>();
            return list.ToArray();
        }

        /// <summary>
        /// btye[]转字符串
        /// </summary>
        /// <param name="byt"></param>
        /// <returns></returns>
        public string ByteToJson(byte[] byt)
        {
            List<byte> list = byt.ToList();
            return new JArray(list).ToString(Newtonsoft.Json.Formatting.None);
        }

        #endregion

        #region 取脚本相关操作
        /// <summary>
        /// 取客户端的ID
        /// </summary>
        protected JObject GetClientIDS(params ControlBase[] ctrls)
        {
            JObject jo = new JObject();
            foreach (ControlBase ctrl in ctrls)
            {
                jo.Add(ctrl.ID, ctrl.ClientID);
            }
            return jo;
        }
        #endregion

        #region 获取菜单和权限

        public List<MenuInfo> MenuList
        {
            get
            {
                List<MenuInfo> list = Session["MenuList"] as List<MenuInfo>;
                if (list != null)
                    return list;

                list = menuDao.GetUserMenus(UserId, MenuType.Web);
                Session["MenuList"] = list;
                return list;
            }
            set
            {
                Session["MenuList"] = value;
            }
        }

        private List<Module> ModuleList
        {
            get
            {
                List<Module> list = Session["ModuleList"] as List<Module>;
                if (list != null)
                    return list;

                list = moduleDao.GetUserModules(UserId);
                Session["ModuleList"] = list;
                return list;
            }
            set
            {
                Session["ModuleList"] = value;
            }
        }

        protected List<Permission> PermissionList
        {
            get
            {
                var list = Session["AuthorityList"] as List<Permission>;
                if (list != null)
                    return list;

                list = permissionDao.GetUserPermissions(UserId);
                Session["AuthorityList"] = list;
                return list;
            }
            set
            {
                Session["AuthorityList"] = value;
            }
        }
        #endregion

        public string GetPathUri()
        {
            string url = "http://" + Request.ServerVariables["HTTP_HOST"].ToString() + Request.ServerVariables["PATH_INFO"].ToString();  //获得URL的值            
            url = url.Substring(0, url.LastIndexOf("/"));
            return url;
        }

        public string GetServerUri()
        {
            return "http://" + Request.ServerVariables["HTTP_HOST"].ToString() + ResolveUrl("~/");  //获得URL的值 
        }
    }
}