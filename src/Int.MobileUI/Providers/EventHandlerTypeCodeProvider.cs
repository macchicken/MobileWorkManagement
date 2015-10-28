using ECommon.Components;
using ENode.Eventing;
using ENode.Infrastructure.Impl;
using Int.PM.ReadModel.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.MobileUI.Providers
{
    [Component]
    public class EventHandlerTypeCodeProvider : DefaultTypeCodeProvider<IEventHandler>
    {
        public EventHandlerTypeCodeProvider()
        {
            RegisterType<ProjectViewModelGenerator>(170);
            RegisterType<NotificationGenerator>(190);
        }
    }
}
