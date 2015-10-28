using ECommon.Components;
using ENode.Commanding;
using ENode.EQueue;
using Int.PM.Commands.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.MobileUI.Providers
{
    [Component]
    public class CommandTopicProvider : AbstractTopicProvider<ICommand>
    {
        public CommandTopicProvider()
        {
            RegisterTopic("ProjectCommandTopic", typeof(StartTrainingProject),typeof(UpdateTrainingProject),typeof(StartConsultProject),typeof(UpdateConsultProject),
                typeof(StartProjectFlow), typeof(UpdateProjectFlow),typeof(CreateProposal),typeof(UpdateProposal),typeof(CreateSubProcess),typeof(UpdateSubProcess),
                typeof(CreateControlData),typeof(UpdateControlTable),typeof(CreateAssessment),typeof(UpdateAssessment));
            RegisterTopic("NotificationCommandTopic", typeof(ProjectNotification));
        }
    }
}