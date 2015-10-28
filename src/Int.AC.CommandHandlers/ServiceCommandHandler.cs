using ENode.Commanding;
using Int.AC.Commands.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Int.AC.Services;
using ECommon.Components;

namespace Int.AC.CommandHandlers
{
    [Component]
    public class ServiceCommandHandler : ICommandHandler<CreateService>,
        ICommandHandler<UpdateService>
    {
        public void Handle(ICommandContext context, CreateService command)
        {
            context.Add(new Service(
                 command.AggregateRootId,
                 command.Name,
                 command.Sort,
                 command.Url));
        }
        public void Handle(ICommandContext context, UpdateService command)
        {
            context.Get<Service>(command.AggregateRootId).Update(
                command.Name,
                command.Sort,
                command.Url);
        }
    }
}
