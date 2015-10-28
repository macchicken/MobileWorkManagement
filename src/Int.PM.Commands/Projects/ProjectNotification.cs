using ECommon.Utilities;
using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.Commands.Projects
{
    [Serializable]
    public class ProjectNotification: AggregateCommand<string>,ICreatingAggregateCommand
    {
        public string Server { get; private set; }
        public string DestEmail { get; private set; }
        public string Subject { get; private set; }
        public string Body { get; private set; }

        public ProjectNotification(string server, string destEmail, string subject, string body)
        {
            AggregateRootId = ObjectId.GenerateNewStringId();
            Server=server;
            DestEmail=destEmail;
            Subject=subject;
            Body = body;
        }
    }
}
