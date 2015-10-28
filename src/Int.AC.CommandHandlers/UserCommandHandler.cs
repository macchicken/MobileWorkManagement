using ENode.Commanding;
using Int.AC.Commands.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Int.AC.Users;
using ECommon.Components;

namespace Int.AC.CommandHandlers
{
    [Component]
    public class UserCommandHandler : ICommandHandler<CreateUser>,
        ICommandHandler<UpdateUser>,
        ICommandHandler<ChangePassword>,
        ICommandHandler<SetUserRoles>
    {
        public void Handle(ICommandContext context, CreateUser command)
        {
            context.Add(new User(
                 command.AggregateRootId,
                 command.Code,
                 command.Name,
                 command.NameEn,
                 command.Email,
                 command.Phone,
                 command.JobName,
                 command.LeaderId
            ));
        }
        public void Handle(ICommandContext context, UpdateUser command)
        {
            context.Get<User>(command.AggregateRootId).Update(
                command.Code,
                command.Name,
                command.NameEn,
                command.Email,
                command.Phone,
                command.JobName,
                command.LeaderId,
                command.UseAble
            );
        }
        public void Handle(ICommandContext context, ChangePassword command)
        {
            context.Get<User>(command.AggregateRootId).ChangePassword(
                command.Password
            );
        }
        public void Handle(ICommandContext context, SetUserRoles command)
        {
            context.Get<User>(command.AggregateRootId).ChangeRoles(
                command.RoleIds
            );
        }
    }
}
