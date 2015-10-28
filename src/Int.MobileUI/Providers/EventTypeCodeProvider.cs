using ECommon.Components;
using ENode.Eventing;
using ENode.Infrastructure.Impl;
using Int.PM.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.MobileUI.Providers
{
    [Component]
    public class EventTypeCodeProvider : DefaultTypeCodeProvider<IEvent>
    {
        public EventTypeCodeProvider()
        {
            RegisterType<TrainingStartedEvent>(170);
            RegisterType<TrainingUpdatedEvent>(171);
            RegisterType<ConsultStartedEvent>(172);
            RegisterType<ConsultUpdatedEvent>(173);
            RegisterType<ProjectFLowEvent>(174);
            RegisterType<ProposalStartedEvent>(175);
            RegisterType<ProposalUpdatedEvent>(176);
            RegisterType<SubprocessStartedEvent>(177);
            RegisterType<SubprocessUpdatedEvent>(178);
            RegisterType<ProjectFlowUpdatedEvent>(179);
            RegisterType<ControlTableItemCreated>(180);
            RegisterType<AssessmentRecordCreated>(181);
            RegisterType<AssessmentRecordUpdated>(182);
            RegisterType<ControlTableItemUpdated>(183);
            RegisterType<NotificationEvents>(190);
        }
    }
}
