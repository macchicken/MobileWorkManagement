using ECommon.Components;
using ENode.EQueue;
using ENode.Eventing;
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
    public class EventTopicProvider : AbstractTopicProvider<IEvent>
    {
        public EventTopicProvider()
        {
            RegisterTopic("DepartmentEventTopic", typeof(DepartmentCreated), typeof(DepartmentUpdated));
            RegisterTopic("MenuEventTopic", typeof(MenuCreated), typeof(MenuUpdated));
            RegisterTopic("ModuleEventTopic", typeof(ModuleCreated), typeof(ModuleUpdated));
            RegisterTopic("PermissionEventTopic", typeof(PermissionCreated), typeof(PermissionUpdated));
            RegisterTopic("RoleEventTopic", typeof(RoleCreated), typeof(RoleUpdated));
            RegisterTopic("ServiceEventTopic", typeof(ServiceCreated), typeof(ServiceUpdated));
            RegisterTopic("UserEventTopic", typeof(UserCreated), typeof(UserUpdated), typeof(PasswordChanged));
        }
    }
}
