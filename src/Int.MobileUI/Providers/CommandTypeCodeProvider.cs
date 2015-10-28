using ECommon.Components;
using ENode.Commanding;
using ENode.Infrastructure.Impl;
using Int.PM.Commands.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.MobileUI.Providers
{
    [Component]
    public class CommandTypeCodeProvider : DefaultTypeCodeProvider<ICommand>
    {
        public CommandTypeCodeProvider()
        {
            RegisterType<StartTrainingProject>(170);
            RegisterType<UpdateTrainingProject>(171);
            RegisterType<StartConsultProject>(172);
            RegisterType<UpdateConsultProject>(173);
            RegisterType<StartProjectFlow>(174);
            RegisterType<CreateProposal>(175);
            RegisterType<UpdateProposal>(176);
            RegisterType<CreateSubProcess>(177);
            RegisterType<UpdateSubProcess>(178);
            RegisterType<UpdateProjectFlow>(179);
            RegisterType<CreateControlData>(180);
            RegisterType<CreateAssessment>(181);
            RegisterType<UpdateAssessment>(182);
            RegisterType<UpdateControlTable>(183);
            RegisterType<ProjectNotification>(190);
        }
    }
}
