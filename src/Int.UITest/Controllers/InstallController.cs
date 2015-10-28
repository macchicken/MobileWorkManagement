using ENode.Commanding;
using Int.AC.Commands.Departments;
using Int.AC.ReadModel.Menus;
using Int.AC.ReadModel.Modules;
using Int.AC.ReadModel.Permissions;
using Int.AC.ReadModel.Roles;
using Int.AC.ReadModel.Services;
using Int.AC.ReadModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Autofac;
using Int.AC.Commands.Users;
using Int.AC.Commands.Roles;
using Int.AC.Commands.Services;
using Int.AC.Commands.Menus;
using Int.AC.Commands.Modules;
using Int.AC.Commands.Permissions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Int.UITest.Controllers
{
    public class InstallController : Controller
    {
        string serviceId = "AC";
        int serviceSort = 10000;
        private readonly ICommandService commandService;
        private readonly IServiceDao serviceDao;
        private readonly IPermissionDao permissionDao;

        public InstallController(ICommandService commandService, IServiceDao serviceDao, IPermissionDao permissionDao)
        {
            this.commandService = commandService;
            this.serviceDao = serviceDao;
            this.permissionDao = permissionDao;
        }

        public async Task<ActionResult> Index()
        {
            serviceId = "AC";
            serviceSort = 10000;
            if (serviceDao.Entities.Where(m => m.Id == serviceId).Count() > 0)
            {
                return Content("数据库中已经存在数据库，不需要重新生成。");
            }
            //部门
            CreateDepartment();

            var service = new CreateService(serviceId, "统一授权中心", 1, "http://int.zhongyi-itl.com/");
            await this.commandService.Execute(service);

            var user = new CreateUser("sysadmin", "系统管理员", "Sysadmin", "admin@zhongyi-itl.com", "15817439909", "系统管理员");
            await this.commandService.Execute(user);

            var role = new CreateRole("系统管理员", 0);
            await this.commandService.Execute(role);
            await this.commandService.Execute(new SetUserRoles(user.AggregateRootId, new string[] { role.AggregateRootId }));


            var menu = new CreateMenu("统一授权中心", (int)MenuType.Web, "", "", serviceSort);
            await this.commandService.Execute(menu);
            var menuRoot = menu.AggregateRootId;

            var module = new CreateModule(serviceId, "System", "系统管理", serviceSort);
            await this.commandService.Execute(module);
            var moduleId = module.AggregateRootId;

            menu = new CreateMenu("系统管理", (int)MenuType.Web, "", "", serviceSort + 10, menuRoot);
            await this.commandService.Execute(menu);
            var menuId = menu.AggregateRootId;

            string moduleId2 = await QuickModule("Sys", "Department", "部门信息", moduleId, menuId, 11);

            var permission = new CreatePermission("DepartmentUser", "设置用户", moduleId2);
            await this.commandService.Execute(permission);

            //角色管理
            module = new CreateModule(serviceId, "Role", "角色管理", serviceSort + 16, moduleId);
            await this.commandService.Execute(module);
            permission = new CreatePermission("ViewRole", "查看", module.AggregateRootId);
            await this.commandService.Execute(permission);
            var viewRolePermissionId = permission.AggregateRootId;
            menu = new CreateMenu("角色管理", (int)MenuType.Web, "Sys/RoleList.aspx", "", serviceSort + 16, menuId, permission.AggregateRootId);
            await this.commandService.Execute(menu);
            permission = new CreatePermission("NewRole", "新增", module.AggregateRootId);
            await this.commandService.Execute(permission);
            permission = new CreatePermission("ModifyRole", "编辑", module.AggregateRootId);
            await this.commandService.Execute(permission);
            permission = new CreatePermission("DeleteRole", "删除", module.AggregateRootId);
            await this.commandService.Execute(permission);
            permission = new CreatePermission("PermissionRole", "分配权限", module.AggregateRootId);
            await this.commandService.Execute(permission);
            await this.commandService.Execute(new SetRolePermissions(role.AggregateRootId, new string[] { viewRolePermissionId, permission.AggregateRootId }));

            //用户管理
            moduleId2 = await QuickModule("Sys", "User", "用户管理", moduleId, menuId, 21);
            await this.commandService.Execute(permission);
            permission = new CreatePermission("ChangePwdUser", "修改密码", moduleId2);
            await this.commandService.Execute(permission);
            permission = new CreatePermission("RoleUser", "分配角色", moduleId2);
            await this.commandService.Execute(permission);
            await QuickModule("Sys", "Service", "服务管理", moduleId, menuId, 26);
            await QuickModule("Sys", "Module", "模块管理", moduleId, menuId, 31);
            await QuickModule("Sys", "Menu", "菜单管理", moduleId, menuId, 36);
            await QuickModule("Sys", "Authority", "权限管理", moduleId, menuId, 41);

            CreateRole();
            return Content("");
        }

        private async void CreateDepartment()
        {
            var department = new CreateDepartment("100000", "中谊前海总部");
            var result = await this.commandService.Execute(department);
            var parentId1 = department.AggregateRootId;
            if (result.Status == CommandStatus.Success)
            {
                department = new CreateDepartment("101000", "领导层", parentId1);
                await this.commandService.Execute(department);

                department = new CreateDepartment("102000", "计划财务部", parentId1);
                await this.commandService.Execute(department);

                department = new CreateDepartment("103000", "综合管理部", parentId1);
                result = await this.commandService.Execute(department);
                var parentId2 = department.AggregateRootId;
                if (result.Status == CommandStatus.Success)
                {
                    department = new CreateDepartment("103010", "深圳", parentId2);
                    await this.commandService.Execute(department);
                    department = new CreateDepartment("103020", "上海", parentId2);
                    await this.commandService.Execute(department);
                    department = new CreateDepartment("103030", "北京", parentId2);
                    await this.commandService.Execute(department);
                }
                department = new CreateDepartment("104000", "教研中心", parentId1);
                result = await this.commandService.Execute(department);
                parentId2 = department.AggregateRootId;
                if (result.Status == CommandStatus.Success)
                {
                    department = new CreateDepartment("104010", "产品研发室", parentId2);
                    await this.commandService.Execute(department);
                    department = new CreateDepartment("104020", "专业认证室", parentId2);
                    await this.commandService.Execute(department);
                    department = new CreateDepartment("104030", "讯息技术室", parentId2);
                    await this.commandService.Execute(department);
                }
                department = new CreateDepartment("105000", "运营中心", parentId1);
                result = await this.commandService.Execute(department);
                parentId2 = department.AggregateRootId;
                if (result.Status == CommandStatus.Success)
                {
                    department = new CreateDepartment("105010", "项目室", parentId2);
                    await this.commandService.Execute(department);
                    department = new CreateDepartment("105020", "商务室", parentId2);
                    await this.commandService.Execute(department);
                }
                department = new CreateDepartment("200000", "中谊猎头");
                result = await this.commandService.Execute(department);
                parentId1 = department.AggregateRootId;
                if (result.Status == CommandStatus.Success)
                {
                    department = new CreateDepartment("201000", "上海分公司", parentId1);
                    result = await this.commandService.Execute(department);
                    parentId2 = department.AggregateRootId;
                    if (result.Status == CommandStatus.Success)
                    {
                        department = new CreateDepartment("201010", "银行组", parentId2);
                        await this.commandService.Execute(department);
                        department = new CreateDepartment("201020", "证券组", parentId2);
                        await this.commandService.Execute(department);
                        department = new CreateDepartment("201030", "保险组", parentId2);
                        await this.commandService.Execute(department);
                        department = new CreateDepartment("201040", "房产组", parentId2);
                        await this.commandService.Execute(department);
                    }
                    department = new CreateDepartment("202000", "深圳团队", parentId1);
                    result = await this.commandService.Execute(department);
                    parentId2 = department.AggregateRootId;
                    if (result.Status == CommandStatus.Success)
                    {
                        department = new CreateDepartment("202010", "金融组", parentId2);
                        await this.commandService.Execute(department);
                    }
                    department = new CreateDepartment("203000", "北京团队", parentId1);
                    result = await this.commandService.Execute(department);
                    parentId2 = department.AggregateRootId;
                    if (result.Status == CommandStatus.Success)
                    {
                        department = new CreateDepartment("203010", "金融组", parentId2);
                        await this.commandService.Execute(department);
                    }
                }
                department = new CreateDepartment("300000", "前海培训");
                result = await this.commandService.Execute(department);
                parentId1 = department.AggregateRootId;
                if (result.Status == CommandStatus.Success)
                {
                    department = new CreateDepartment("301000", "华南团队", parentId1);
                    await this.commandService.Execute(department);
                    department = new CreateDepartment("302000", "华北团队", parentId1);
                    await this.commandService.Execute(department);
                    department = new CreateDepartment("303000", "华东团队", parentId1);
                    await this.commandService.Execute(department);
                }
                department = new CreateDepartment("400000", "中谊香港学院");
                result = await this.commandService.Execute(department);
                parentId1 = department.AggregateRootId;
                if (result.Status == CommandStatus.Success)
                {
                    department = new CreateDepartment("401000", "香港团队", parentId1);
                    await this.commandService.Execute(department);
                }
            }
        }

        private async void CreateRole()
        {
            var role = new CreateRole("在职员工", 0);
            await this.commandService.Execute(role);

            role = new CreateRole("离职员工", 0);
            await this.commandService.Execute(role);

            role = new CreateRole("领导层", 0);
            await this.commandService.Execute(role);

            role = new CreateRole("财务", 0);
            await this.commandService.Execute(role);

            role = new CreateRole("综合管理", 0);
            await this.commandService.Execute(role);

            role = new CreateRole("产品研发", 0);
            await this.commandService.Execute(role);

            role = new CreateRole("专业认证", 0);
            await this.commandService.Execute(role);

            role = new CreateRole("讯息技术", 0);
            await this.commandService.Execute(role);

            role = new CreateRole("项目室", 0);
            await this.commandService.Execute(role);

            role = new CreateRole("商务室", 0);
            await this.commandService.Execute(role);

            role = new CreateRole("猎头经理", 0);
            await this.commandService.Execute(role);

            role = new CreateRole("猎头顾问", 0);
            await this.commandService.Execute(role);

            role = new CreateRole("猎头研究员", 0);
            await this.commandService.Execute(role);

            role = new CreateRole("前海培训业务总监", 0);
            await this.commandService.Execute(role);

            role = new CreateRole("前海培训客户经理", 0);
            await this.commandService.Execute(role);
        }

        //private async void QuickModuleGroup(string moduleCode, string moduleName, string moduleParentId, string menuParentId, int sort, out string moduleId, out string menuId)
        //{
        //    var module = new CreateModule(serviceId, moduleCode, moduleName, serviceSort + sort, moduleParentId);
        //    await this.commandService.Execute(module);
        //    moduleId = module.AggregateRootId;

        //    var menu = new CreateMenu(moduleName, (int)MenuType.Web, "", "", serviceSort + sort, menuParentId);
        //    await this.commandService.Execute(menu);
        //    menuId = menu.AggregateRootId;
        //}

        private async Task<string> QuickModule(string folder, string moduleCode, string moduleName, string moduleParentId, string menuParentId, int sort, bool canExport = false)
        {
            var module = new CreateModule(serviceId, moduleCode, moduleName, serviceSort + sort, moduleParentId);
            var result = await this.commandService.Execute(module);
            if (result.Status == CommandStatus.Success)
            {
                var permission = new CreatePermission("View" + moduleCode, "查看", module.AggregateRootId);
                result = await this.commandService.Execute(permission);
                if (result.Status == CommandStatus.Success)
                {
                    var menu = new CreateMenu(moduleName, (int)MenuType.Web, folder + "/" + moduleCode + "List.aspx", "", serviceSort + sort, menuParentId, permission.AggregateRootId);
                    await this.commandService.Execute(menu);
                }
                permission = new CreatePermission("New" + moduleCode, "新增", module.AggregateRootId);
                await this.commandService.Execute(permission);
                permission = new CreatePermission("Modify" + moduleCode, "编辑", module.AggregateRootId);
                await this.commandService.Execute(permission);
                permission = new CreatePermission("Delete" + moduleCode, "删除", module.AggregateRootId);
                await this.commandService.Execute(permission);

                if (canExport)
                {
                    permission = new CreatePermission("Upload" + moduleCode, "上传", module.AggregateRootId);
                    await this.commandService.Execute(permission);
                    permission = new CreatePermission("Download" + moduleCode, "下载", module.AggregateRootId);
                    await this.commandService.Execute(permission);
                }
            }
            return module.AggregateRootId;
        }

        private async void QuickFileModule(string moduleCode, string moduleName, string moduleParentId, string menuParentId, int sort)
        {
            var module = new CreateModule(serviceId, moduleCode, moduleName, serviceSort + sort, moduleParentId);
            await this.commandService.Execute(module);

            var permission = new CreatePermission("Use" + moduleCode, "使用", module.AggregateRootId);
            await this.commandService.Execute(permission);

            var menu = new CreateMenu(moduleName, (int)MenuType.Web, "HardDisk/" + moduleCode + "aspx", "", serviceSort + sort, menuParentId, permission.AggregateRootId);
            await this.commandService.Execute(menu);

            permission = new CreatePermission("Upload" + moduleCode, "上传文件", module.AggregateRootId);
            await this.commandService.Execute(permission);
            permission = new CreatePermission("ModifyFile" + moduleCode, "编辑文件名", module.AggregateRootId);
            await this.commandService.Execute(permission);
            permission = new CreatePermission("DeleteFile" + moduleCode, "删除文件", module.AggregateRootId);
            await this.commandService.Execute(permission);
            permission = new CreatePermission("MoveFile" + moduleCode, "移动文件", module.AggregateRootId);
            await this.commandService.Execute(permission);
            permission = new CreatePermission("NewFolder" + moduleCode, "新建文件夹", module.AggregateRootId);
            await this.commandService.Execute(permission);
            permission = new CreatePermission("ModifyFolder" + moduleCode, "编辑文件夹", module.AggregateRootId);
            await this.commandService.Execute(permission);
            permission = new CreatePermission("DeleteFolder" + moduleCode, "删除文件夹", module.AggregateRootId);
            await this.commandService.Execute(permission);
            permission = new CreatePermission("MoveFolder" + moduleCode, "移动文件夹", module.AggregateRootId);
            await this.commandService.Execute(permission);
        }
   
	}
}