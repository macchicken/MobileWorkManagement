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
    public class StartProjectFlow : AggregateCommand<string>, ICreatingAggregateCommand
    {
        public string Username { get; private set; }
        public string ProjectType { get; private set; }
        public DateTime ProjectCreatedTime { get; private set; }

        public StartProjectFlow(string userName, string projectType, DateTime projectCreadtedTime)
        {
            AggregateRootId = ObjectId.GenerateNewStringId();
            Username = userName;
            ProjectType = projectType;
            ProjectCreatedTime = projectCreadtedTime;
        }
    }
}
