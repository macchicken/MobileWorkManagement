using ENode.Commanding;
using Int.AC.Commands.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Int.AC.Menus;
using ECommon.Components;

namespace Int.AC.CommandHandlers
{
    [Component]
    public class MenuCommandHandler : ICommandHandler<CreateMenu>,
        ICommandHandler<UpdateMenu>
    {
        public void Handle(ICommandContext context, CreateMenu command)
        {
            context.Add(new Menu(
                 command.AggregateRootId,
                 command.Text,
                 command.MenuType,
                 command.NavigateUrl,
                 command.MobileUrl,
                 command.ParentId,
                 command.Sort,
                 command.PermissionId
            ));
        }
        public void Handle(ICommandContext context, UpdateMenu command)
        {
            context.Get<Menu>(command.AggregateRootId).Update(
                command.Text,
                command.MenuType,
                command.NavigateUrl,
                command.MobileUrl,
                command.ParentId,
                command.Sort,
                command.PermissionId,
                command.UseAble
            );
        }
    }
}
