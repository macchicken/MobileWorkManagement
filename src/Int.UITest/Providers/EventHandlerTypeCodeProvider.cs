using ECommon.Components;
using ENode.Eventing;
using ENode.Infrastructure.Impl;
using Int.AC.ReadModel.Departments;
using Int.AC.ReadModel.Menus;
using Int.AC.ReadModel.Modules;
using Int.AC.ReadModel.Permissions;
using Int.AC.ReadModel.Roles;
using Int.AC.ReadModel.Services;
using Int.AC.ReadModel.Users;
using Int.AC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.UITest.Providers
{
    [Component]
    public class EventHandlerTypeCodeProvider : DefaultTypeCodeProvider<IEventHandler>
    {
        public EventHandlerTypeCodeProvider()
        {
            RegisterType<DepartmentViewModelGenerator>(100);
            RegisterType<MenuViewModelGenerator>(110);
            RegisterType<ModuleViewModelGenerator>(120);
            RegisterType<PermissionViewModelGenerator>(130);
            RegisterType<RoleViewModelGenerator>(140);
            RegisterType<ServiceViewModelGenerator>(150);
            RegisterType<UserViewModelGenerator>(160);
        }
    }
}
