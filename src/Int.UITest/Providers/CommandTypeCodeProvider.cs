using ECommon.Components;
using ENode.Commanding;
using ENode.Infrastructure.Impl;
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
    public class CommandTypeCodeProvider : DefaultTypeCodeProvider<ICommand>
    {
        public CommandTypeCodeProvider()
        {
            RegisterType<CreateDepartment>(100);
            RegisterType<UpdateDepartment>(101);
            RegisterType<CreateMenu>(110);
            RegisterType<UpdateMenu>(111);
            RegisterType<CreateModule>(120);
            RegisterType<UpdateModule>(121);
            RegisterType<CreatePermission>(130);
            RegisterType<UpdatePermission>(131);
            RegisterType<CreateRole>(140);
            RegisterType<UpdateRole>(141);
            RegisterType<CreateService>(150);
            RegisterType<UpdateService>(151);
            RegisterType<CreateUser>(160);
            RegisterType<UpdateUser>(161);
            RegisterType<ChangePassword>(162);
        }
    }
}
