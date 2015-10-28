using ECommon.Components;
using ENode.Domain;
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
    public class AggregateRootTypeCodeProvider : DefaultTypeCodeProvider<IAggregateRoot>
    {
        public AggregateRootTypeCodeProvider()
        {
            RegisterType<Department>(100);
            RegisterType<Menu>(110);
            RegisterType<Module>(120);
            RegisterType<Permission>(130);
            RegisterType<Role>(140);
            RegisterType<Service>(150);
            RegisterType<User>(160);
        }
    }
}