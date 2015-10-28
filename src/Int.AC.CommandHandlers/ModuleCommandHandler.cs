using ENode.Commanding;
using Int.AC.Commands.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Int.AC.Modules;
using ECommon.Components;

namespace Int.AC.CommandHandlers
{
    [Component]
    public class ModuleCommandHandler : ICommandHandler<CreateModule>,
        ICommandHandler<UpdateModule>
    {
        public void Handle(ICommandContext context, CreateModule command)
        {
            context.Add(new Module(
                 command.AggregateRootId,
                 command.ServiceId,
                 command.Code,
                 command.Text,
                 command.ParentId,
                 command.Sort
            ));
        }
        public void Handle(ICommandContext context, UpdateModule command)
        {
            context.Get<Module>(command.AggregateRootId).Update(
                command.Code,
                command.Text,
                command.ParentId,
                command.Sort,
                command.UseAble
            );
        }
    }
}
