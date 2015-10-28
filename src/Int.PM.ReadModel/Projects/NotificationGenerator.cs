using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Int.PM.Projects;
using ENode.Eventing;
using ENode.Infrastructure;
using ECommon.Components;

namespace Int.PM.ReadModel.Projects
{
    [Component]
    public class NotificationGenerator : BaseEventHandler, IEventHandler<NotificationEvents>
    {
        public void Handle(IHandlingContext context, NotificationEvents evnt)
        {
            if (!String.IsNullOrWhiteSpace(evnt.Server)){
                MailMessageHelper.CreateMessage(evnt.DestEmail,evnt.Subject,evnt.Body,evnt.Server);
            }
            else
            {
                MailMessageHelper.CreateMessage(evnt.DestEmail, evnt.Subject, evnt.Body);
            }
        }
    }
}
