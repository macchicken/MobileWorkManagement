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
    public class ProjectCommandHandler : ICommandHandler<StartTrainingProject>, ICommandHandler<UpdateTrainingProject>,
        ICommandHandler<StartConsultProject>, ICommandHandler<UpdateConsultProject>, ICommandHandler<StartProjectFlow>,
        ICommandHandler<CreateProposal>, ICommandHandler<UpdateProposal>, ICommandHandler<CreateSubProcess>, ICommandHandler<UpdateSubProcess>,
        ICommandHandler<UpdateProjectFlow>, ICommandHandler<CreateControlData>,ICommandHandler<UpdateControlTable>, 
        ICommandHandler<CreateAssessment>, ICommandHandler<UpdateAssessment>
    {
        public void Handle(ICommandContext context, StartTrainingProject cmd)
        {
            context.Get<Project>(cmd.AggregateRootId).AddTrainProject(cmd.AggregateRootId,cmd.TrainingTarget, cmd.NumOfPerson, cmd.ReceivedTime, cmd.Days,
                cmd.ExpectTime,cmd.CourseTitle,cmd.ProjectContact,cmd.Decision,cmd.ProjectOrigin,cmd.Rival,
                cmd.Bid,cmd.ProjectPossi,cmd.CusProBudget,cmd.ProjectEmergency,cmd.CourseSubject,
                cmd.CourseDetail,cmd.CourseOther);
        }

        public void Handle(ICommandContext context, UpdateTrainingProject cmd)
        {
            context.Get<Project>(cmd.AggregateRootId).UpdateTrain(cmd.AggregateRootId, cmd.TrainingTarget, cmd.NumOfPerson, cmd.ReceivedTime, cmd.Days,
                cmd.ExpectTime,cmd.CourseTitle,cmd.ProjectContact,cmd.Decision,cmd.ProjectOrigin,cmd.Rival,
                cmd.Bid,cmd.ProjectPossi,cmd.CusProBudget,cmd.ProjectEmergency,cmd.CourseSubject,
                cmd.CourseDetail,cmd.CourseOther);
        }

        public void Handle(ICommandContext context, StartConsultProject cmd)
        {
            context.Get<Project>(cmd.AggregateRootId).AddConsultProject(cmd.AggregateRootId,cmd.Rname, cmd.Area, cmd.RTelephone, cmd.REmail, cmd.CusBank,
                cmd.CusMainBranch, cmd.CusSubBranch, cmd.CusContact, cmd.CusTelephone, cmd.CusEmail, cmd.ProjectRtype,
                cmd.RequireDept, cmd.Duration, cmd.Relvant, cmd.ReceivedTime, cmd.ExpectTime, cmd.ProjectContact, cmd.Decision,
                cmd.ProjectOrigin, cmd.Rival, cmd.Bid, cmd.ProjectPossi, cmd.CusProBudget, cmd.ProjectEmergency,
                cmd.CourseSubject, cmd.CourseDetail, cmd.CourseOther);
        }

        public void Handle(ICommandContext context, UpdateConsultProject cmd)
        {
            context.Get<Project>(cmd.AggregateRootId).UpdateConsult(cmd.AggregateRootId, cmd.Rname, cmd.Area, cmd.RTelephone, cmd.REmail, cmd.CusBank,
                cmd.CusMainBranch, cmd.CusSubBranch, cmd.CusContact, cmd.CusTelephone, cmd.CusEmail, cmd.ProjectRtype,
                cmd.RequireDept, cmd.Duration, cmd.Relvant, cmd.ReceivedTime, cmd.ExpectTime, cmd.ProjectContact, cmd.Decision,
                cmd.ProjectOrigin, cmd.Rival, cmd.Bid, cmd.ProjectPossi, cmd.CusProBudget, cmd.ProjectEmergency,
                cmd.CourseSubject, cmd.CourseDetail, cmd.CourseOther);
        }

        public void Handle(ICommandContext context, StartProjectFlow cmd)
        {
            context.Add(new Project(cmd.AggregateRootId,cmd.Username, cmd.ProjectType, cmd.ProjectCreatedTime));
        }
        public void Handle(ICommandContext context, UpdateProjectFlow cmd)
        {
            context.Get<Project>(cmd.AggregateRootId).UpdateProjectFlow(cmd.AggregateRootId, cmd.State);
        }
        public void Handle(ICommandContext context, CreateProposal cmd)
        {
            context.Get<Project>(cmd.AggregateRootId).AddProposal(cmd.AggregateRootId, cmd.State, cmd.ProposalOwner, cmd.ProposalStart);
        }
        public void Handle(ICommandContext context, UpdateProposal cmd)
        {
            context.Get<Project>(cmd.AggregateRootId).UpdateProposal(cmd.AggregateRootId, cmd.State, cmd.ProposalOwner);
        }

        public void Handle(ICommandContext context, CreateSubProcess cmd)
        {
            context.Get<Project>(cmd.AggregateRootId).AddSubprocess(cmd.AggregateRootId, cmd.TypeCode, cmd.State, cmd.Content);
        }
        public void Handle(ICommandContext context, UpdateSubProcess cmd)
        {
            context.Get<Project>(cmd.AggregateRootId).UpdateSubprocess(cmd.AggregateRootId, cmd.TypeCode,cmd.State, cmd.Content);
        }
        public void Handle(ICommandContext context, CreateControlData cmd)
        {
            context.Get<Project>(cmd.AggregateRootId).AddControlTableItem(cmd.AggregateRootId, cmd.Order, cmd.Time, cmd.Type, cmd.Name, cmd.Content, cmd.Remark);
        }

        public void Handle(ICommandContext context, CreateAssessment cmd)
        {
            context.Get<Project>(cmd.AggregateRootId).CreateAssessmentRecord(cmd.AggregateRootId, cmd.Order, cmd.Time, cmd.Type, cmd.Name, cmd.Score);
        }

        public void Handle(ICommandContext context, UpdateAssessment cmd)
        {
            context.Get<Project>(cmd.AggregateRootId).UpdateAssessmentRecord(cmd.AggregateRootId, cmd.Order,cmd.Time, cmd.Type, cmd.Name, cmd.Score);
        }

        public void Handle(ICommandContext context, UpdateControlTable cmd)
        {
            context.Get<Project>(cmd.AggregateRootId).ModifyControlTableItem(cmd.AggregateRootId, cmd.Order, cmd.Time, cmd.Type, cmd.Name, cmd.Content, cmd.Remark);
        }
    }
}
