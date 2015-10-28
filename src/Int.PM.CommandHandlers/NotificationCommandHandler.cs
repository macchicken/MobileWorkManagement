using ECommon.Components;
using ENode.Commanding;
using Int.PM.Commands.Projects;
using Int.PM.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.CommandHandlers
{
    [Component(LifeStyle.Singleton)]
    public class NotificationCommandHandler : ICommandHandler<ProjectNotification>
    {
        public void Handle(ICommandContext context, ProjectNotification cmd)
        {
            context.Add(new Notification(cmd.AggregateRootId,cmd.Server,cmd.DestEmail,cmd.Subject,cmd.Body));
        }
    }
}
