using ENode.Commanding;
using Int.AC.Commands.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Int.AC.Permissions;
using ECommon.Components;

namespace Int.AC.CommandHandlers
{
    [Component]
    public class PermissionCommandHandler : ICommandHandler<CreatePermission>,
        ICommandHandler<UpdatePermission>
    {
        public void Handle(ICommandContext context, CreatePermission command)
        {
            context.Add(new Permission(
                 command.AggregateRootId,
                 command.Code,
                 command.Name,
                 command.ModuleId
            ));
        }
        public void Handle(ICommandContext context, UpdatePermission command)
        {
            context.Get<Permission>(command.AggregateRootId).Update(
                command.Code,
                command.Name,
                command.ModuleId
            );
        }
    }
}
