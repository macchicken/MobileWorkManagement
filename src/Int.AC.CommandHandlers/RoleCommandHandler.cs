using ENode.Commanding;
using Int.AC.Commands.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Int.AC.Roles;
using ECommon.Components;

namespace Int.AC.CommandHandlers
{
    [Component]
    public class RoleCommandHandler : ICommandHandler<CreateRole>,
        ICommandHandler<UpdateRole>,
        ICommandHandler<SetRolePermissions>
    {
        public void Handle(ICommandContext context, CreateRole command)
        {
            context.Add(new Role(
                 command.AggregateRootId,
                 command.Name,
                 command.Sort
            ));
        }
        public void Handle(ICommandContext context, UpdateRole command)
        {
            context.Get<Role>(command.AggregateRootId).Update(
                command.Name,
                command.Sort,
                command.UseAble
            );
        }
        public void Handle(ICommandContext context, SetRolePermissions command)
        {
            context.Get<Role>(command.AggregateRootId).ChangePermissions(
                command.PermissionIds
            );
        }
    }
}
