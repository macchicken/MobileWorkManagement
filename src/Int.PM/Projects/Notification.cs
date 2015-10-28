using ENode.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.Projects
{
    [Serializable]
    public class Notification : AggregateRoot<string>
    {
        public string _server;
        public string _destEmail;
        public string _subject;
        public string _body;

        public Notification(string id, string server, string destEmail, string subject, string body)
            : base(id)
        {
            ApplyEvent(new NotificationEvents(id,server,destEmail,subject,body));
        }
        private void Handle(NotificationEvents evnt)
        {
            _server = evnt.Server;
            _destEmail = evnt.DestEmail;
            _subject = evnt.Subject;
            _body = evnt.Body;
        }
    }
}
