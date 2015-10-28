using ECommon.Components;
using ENode.Commanding;
using ENode.EQueue;
using Int.AC.Commands.Departments;
using Int.AC.Commands.Menus;
using Int.AC.Commands.Modules;
using Int.AC.Commands.Permissions;
using Int.AC.Commands.Roles;
using Int.AC.Commands.Services;
using Int.AC.Commands.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.UITest.Providers
{
    [Component]
    public class CommandTopicProvider : AbstractTopicProvider<ICommand>
    {
        public CommandTopicProvider()
        {
            RegisterTopic("DepartmentCommandTopic", typeof(CreateDepartment), typeof(UpdateDepartment));
            RegisterTopic("MenuCommandTopic", typeof(CreateMenu), typeof(UpdateMenu));
            RegisterTopic("ModuleCommandTopic", typeof(CreateModule), typeof(UpdateModule));
            RegisterTopic("PermissionCommandTopic", typeof(CreatePermission), typeof(UpdatePermission));
            RegisterTopic("RoleCommandTopic", typeof(CreateRole), typeof(UpdateRole));
            RegisterTopic("ServiceCommandTopic", typeof(CreateService), typeof(UpdateService));
            RegisterTopic("UserCommandTopic", typeof(CreateUser), typeof(UpdateUser), typeof(ChangePassword));
        }
    }
}