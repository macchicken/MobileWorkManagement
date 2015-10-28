using ECommon.Components;
using ENode.EQueue;
using ENode.Eventing;
using Int.PM.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.MobileUI.Providers
{
    [Component]
    public class EventTopicProvider : AbstractTopicProvider<IEvent>
    {
        public EventTopicProvider()
        {
            RegisterTopic("ProjectEventTopic", typeof(TrainingStartedEvent), typeof(TrainingUpdatedEvent), typeof(ConsultStartedEvent), typeof(ConsultUpdatedEvent),
                typeof(ProjectFLowEvent),typeof(ProjectFlowUpdatedEvent),typeof(ProposalStartedEvent),typeof(ProposalUpdatedEvent),typeof(SubprocessStartedEvent),typeof(SubprocessUpdatedEvent),
                typeof(ControlTableItemCreated),typeof(ControlTableItemUpdated),typeof(AssessmentRecordCreated),typeof(AssessmentRecordUpdated));
            RegisterTopic("NotoficationEventTopic", typeof(NotificationEvents));
        }
    }
}
