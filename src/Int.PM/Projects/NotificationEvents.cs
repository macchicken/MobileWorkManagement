using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.Projects
{
    [Serializable]
    public class NotificationEvents: DomainEvent<string>
    {
        public string Server { get; private set; }
        public string DestEmail { get; private set; }
        public string Subject { get; private set; }
        public string Body { get; private set; }

        public NotificationEvents(string id, string server, string destEmail, string subject, string body)
            : base(id)
        {
            Server = server;
            DestEmail = destEmail;
            Subject = subject;
            Body = body;
        }
    }
}
