using ECommon.Components;
using ENode.Domain;
using ENode.Infrastructure.Impl;
using Int.PM.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.MobileUI.Providers
{
    [Component]
    public class AggregateRootTypeCodeProvider : DefaultTypeCodeProvider<IAggregateRoot>
    {
        public AggregateRootTypeCodeProvider()
        {
            RegisterType<Project>(170);
            RegisterType<Notification>(190);
        }
    }
}