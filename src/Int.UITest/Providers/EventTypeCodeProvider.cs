using ECommon.Components;
using ENode.Eventing;
using ENode.Infrastructure.Impl;
using Int.AC.Departments;
using Int.AC.Menus;
using Int.AC.Modules;
using Int.AC.Permissions;
using Int.AC.Roles;
using Int.AC.Services;
using Int.AC.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.UITest.Providers
{
    [Component]
    public class EventTypeCodeProvider : DefaultTypeCodeProvider<IEvent>
    {
        public EventTypeCodeProvider()
        {
            RegisterType<DepartmentCreated>(100);
            RegisterType<DepartmentUpdated>(101);
            RegisterType<MenuCreated>(110);
            RegisterType<MenuUpdated>(111);
            RegisterType<ModuleCreated>(120);
            RegisterType<ModuleUpdated>(121);
            RegisterType<PermissionCreated>(130);
            RegisterType<PermissionUpdated>(131);
            RegisterType<RoleCreated>(140);
            RegisterType<RoleUpdated>(141);
            RegisterType<ServiceCreated>(150);
            RegisterType<ServiceUpdated>(151);
            RegisterType<UserCreated>(160);
            RegisterType<UserUpdated>(161);
            RegisterType<PasswordChanged>(162);
        }
    }
}
