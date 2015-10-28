using ECommon.Components;
using ECommon.Dapper;
using ENode.Eventing;
using ENode.Infrastructure;
using Int.PM.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.ReadModel.Projects
{
    //项目信息以及相关对象数据库操作
    [Component]
    public class ProjectViewModelGenerator : BaseEventHandler, IEventHandler<TrainingStartedEvent>, IEventHandler<TrainingUpdatedEvent>,
         IEventHandler<ConsultStartedEvent>, IEventHandler<ConsultUpdatedEvent>, IEventHandler<ProjectFLowEvent>,IEventHandler<ProjectFlowUpdatedEvent>,
         IEventHandler<ProposalStartedEvent>, IEventHandler<ProposalUpdatedEvent>, IEventHandler<SubprocessStartedEvent>,IEventHandler<SubprocessUpdatedEvent>,
         IEventHandler<ControlTableItemCreated>, IEventHandler<ControlTableItemUpdated>,
         IEventHandler<AssessmentRecordCreated>, IEventHandler<AssessmentRecordUpdated>
    {
        public void Handle(IHandlingContext context, TrainingStartedEvent evnt)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    connection.Insert(new { Id = evnt.AggregateRootId, TrainingTarget=evnt.TrainingTarget,
                                            NumOfPerson = evnt.NumOfPerson,
                                            ReceivedTime=evnt.ReceivedTime,
                                            Days=evnt.Days,
                                            ExpectTime=evnt.ExpectTime,
                                            CourseTitle=evnt.CourseTitle,
                                            IsDeleted = 0,
                                            CreatedOn = evnt.Timestamp,
                                            UpdatedOn = evnt.Timestamp,
                                            Version = evnt.Version
                    }, "ProjectMains", transaction);
                    connection.Insert(new { Id = evnt.AggregateRootId, ProjectContact = evnt.ProjectContact, Decision = evnt.Decision, ProjectOrigin = evnt.ProjectOrigin,
                                            Rival = evnt.Rival,
                                            Bid = evnt.Bid,
                                            ProjectPossi=evnt.ProjectPossi,
                                            CusProBudget=evnt.CusProBudget,
                                            ProjectEmergency=evnt.ProjectEmergency,
                                            CourseSubject=evnt.CourseSubject,
                                            CourseDetail=evnt.CourseDetail,
                                            CourseOther=evnt.CourseOther,
                                            IsDeleted = 0,
                                            CreatedOn = evnt.Timestamp,
                                            UpdatedOn = evnt.Timestamp,
                                            Version = evnt.Version
                    }, "ProjectExtends", transaction);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }
        public void Handle(IHandlingContext context, TrainingUpdatedEvent evnt)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    connection.Update(new
                    {
                        TrainingTarget = evnt.TrainingTarget,
                        NumOfPerson = evnt.NumOfPerson,
                        ReceivedTime = evnt.ReceivedTime,
                        Days = evnt.Days,
                        ExpectTime = evnt.ExpectTime,
                        CourseTitle = evnt.CourseTitle,
                        UpdatedOn = evnt.Timestamp,
                        Version = evnt.Version
                    }, new { Id = evnt.AggregateRootId }, "ProjectMains", transaction);
                    connection.Update(new
                    {
                        Id = evnt.AggregateRootId,
                        ProjectContact = evnt.ProjectContact,
                        Decision = evnt.Decision,
                        ProjectOrigin = evnt.ProjectOrigin,
                        Rival = evnt.Rival,
                        Bid = evnt.Bid,
                        ProjectPossi = evnt.ProjectPossi,
                        CusProBudget = evnt.CusProBudget,
                        ProjectEmergency = evnt.ProjectEmergency,
                        CourseSubject = evnt.CourseSubject,
                        CourseDetail = evnt.CourseDetail,
                        CourseOther = evnt.CourseOther,
                        UpdatedOn = evnt.Timestamp,
                        Version = evnt.Version
                    }, new { Id = evnt.AggregateRootId }, "ProjectExtends", transaction);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }
        public void Handle(IHandlingContext context, ConsultStartedEvent evnt)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    connection.Insert(new
                    {
                        Id = evnt.AggregateRootId,
                        Rname = evnt.Rname,
                        Area = evnt.Area,
                        RTelephone=evnt.RTelephone,
                        REmail = evnt.REmail,
                        CusBank = evnt.CusBank,
                        CusMainBranch = evnt.CusMainBranch,
                        CusSubBranch = evnt.CusSubBranch,
                        CusContact = evnt.CusSubBranch,
                        CusTelephone = evnt.CusTelephone,
                        CusEmail = evnt.CusEmail,
                        ProjectRtype = evnt.ProjectRtype,
                        RequireDept = evnt.RequireDept,
                        Duration = evnt.Duration,
                        Relvant = evnt.Relvant,
                        ReceivedTime = evnt.ReceivedTime,
                        ExpectTime = evnt.ExpectTime,
                        IsDeleted = 0,
                        CreatedOn = evnt.Timestamp,
                        UpdatedOn = evnt.Timestamp,
                        Version = evnt.Version
                    }, "Consults", transaction);
                    connection.Insert(new
                    {
                        Id = evnt.AggregateRootId,
                        ProjectContact = evnt.ProjectContact,
                        Decision = evnt.Decision,
                        ProjectOrigin = evnt.ProjectOrigin,
                        Rival = evnt.Rival,
                        Bid = evnt.Bid,
                        ProjectPossi = evnt.ProjectPossi,
                        CusProBudget = evnt.CusProBudget,
                        ProjectEmergency = evnt.ProjectEmergency,
                        CourseSubject = evnt.CourseSubject,
                        CourseDetail = evnt.CourseDetail,
                        CourseOther = evnt.CourseOther,
                        IsDeleted = 0,
                        CreatedOn = evnt.Timestamp,
                        UpdatedOn = evnt.Timestamp,
                        Version = evnt.Version
                    }, "ProjectExtends", transaction);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }
        public void Handle(IHandlingContext context, ConsultUpdatedEvent evnt)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    connection.Update(new
                    {
                            Rname = evnt.Rname,
                            Area=evnt.Area,
                            REmail=evnt.REmail,
                            CusBank=evnt.CusBank,
                            CusMainBranch=evnt.CusMainBranch,
                            CusSubBranch=evnt.CusSubBranch,
                            CusContact=evnt.CusSubBranch,
                            CusTelephone=evnt.CusTelephone,
                            CusEmail=evnt.CusEmail,
                            ProjectRtype=evnt.ProjectRtype,
                            RequireDept=evnt.RequireDept,
                            Duration=evnt.Duration,
                            Relvant=evnt.Relvant,
                            ReceivedTime=evnt.ReceivedTime,
                            ExpectTime=evnt.ExpectTime,
                            UpdatedOn = evnt.Timestamp,
                            Version = evnt.Version
                    }, new { Id = evnt.AggregateRootId }, "Consults", transaction);
                    connection.Update(new
                    {
                        ProjectContact = evnt.ProjectContact,
                        Decision = evnt.Decision,
                        ProjectOrigin = evnt.ProjectOrigin,
                        Rival = evnt.Rival,
                        Bid = evnt.Bid,
                        ProjectPossi = evnt.ProjectPossi,
                        CusProBudget = evnt.CusProBudget,
                        ProjectEmergency = evnt.ProjectEmergency,
                        CourseSubject = evnt.CourseSubject,
                        CourseDetail = evnt.CourseDetail,
                        CourseOther = evnt.CourseOther,
                        UpdatedOn = evnt.Timestamp,
                        Version = evnt.Version
                    }, new{Id = evnt.AggregateRootId},"ProjectExtends", transaction);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }
        public void Handle(IHandlingContext context, ProjectFLowEvent evnt)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    connection.Insert(new
                    {
                        Id = evnt.AggregateRootId,
                        UserId = evnt.UserName,
                        ProjectCtime = evnt.ProjectCreatedTime,
                        State = 0,
                        ProposalOwner = "",
                        ProjectType = evnt.ProjectType,
                        IsDeleted = 0,
                        CreatedOn = evnt.Timestamp,
                        UpdatedOn = evnt.Timestamp,
                        Version = evnt.Version,
                    }, "Projects", transaction);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }
        public void Handle(IHandlingContext context, ProjectFlowUpdatedEvent evnt)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    connection.Update(new
                    {
                        State = evnt.State,
                        UpdatedOn = evnt.Timestamp,
                        Version = evnt.Version,
                    }, new { Id = evnt.AggregateRootId }, "Projects", transaction);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }
        public void Handle(IHandlingContext context, ProposalStartedEvent evnt)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    connection.Insert(new
                    {
                        Id = evnt.AggregateRootId,
                        State = evnt.State,
                        ProposalOwner = evnt.ProposalOwner,
                        ProposalStart = evnt.ProposalStart,
                        IsDeleted = 0,
                        CreatedOn = evnt.Timestamp,
                        UpdatedOn = evnt.Timestamp,
                        Version = evnt.Version,
                    }, "Proposals", transaction);
                    connection.Update(new { ProposalOwner = evnt.ProposalOwner, State=1, UpdatedOn = evnt.Timestamp, Version = evnt.Version }, 
                        new { Id = evnt.AggregateRootId }, "Projects", transaction);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }
        public void Handle(IHandlingContext context, ProposalUpdatedEvent evnt)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    connection.Update(new
                    {
                        State = evnt.State,
                        ProposalOwner = evnt.ProposalOwner,
                        UpdatedOn = evnt.Timestamp,
                        Version = evnt.Version,
                    }, new { Id = evnt.AggregateRootId }, "Proposals", transaction);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }
        public void Handle(IHandlingContext context, SubprocessStartedEvent evnt)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    connection.Insert(new
                    {
                        Id=evnt.AggregateRootId,
                        TypeCode=evnt.TypeCode,
                        State = evnt.State,
                        Content=evnt.Content,
                        IsDeleted = 0,
                        CreatedOn = evnt.Timestamp,
                        UpdatedOn = evnt.Timestamp,
                        Version = evnt.Version,
                    }, "SubProcesses", transaction);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }
        public void Handle(IHandlingContext context, SubprocessUpdatedEvent evnt)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    connection.Update(new
                    {
                        State = evnt.State,
                        Content = evnt.Content,
                        UpdatedOn = evnt.Timestamp,
                        Version = evnt.Version,
                    }, new { Id = evnt.AggregateRootId, TypeCode = evnt.TypeCode }, "SubProcesses", transaction);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }

        public void Handle(IHandlingContext context, ControlTableItemCreated evnt)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    connection.Insert(new
                    {
                        Id = evnt.AggregateRootId,
                        OrderCode = evnt.Order,
                        Time=evnt.Time,
                        Type = evnt.Type,
                        Name = evnt.Name,
                        Content = evnt.Content,
                        Remark = evnt.Remark,
                        IsDeleted = 0,
                        CreatedOn = evnt.Timestamp,
                        UpdatedOn = evnt.Timestamp,
                        Version = evnt.Version,
                    }, "ControlTables", transaction);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }

        public void Handle(IHandlingContext context, AssessmentRecordUpdated evnt)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    connection.Update(new
                    {
                        Time = evnt.Time,
                        Type = evnt.Type,
                        Name=evnt.Name,
                        Score=evnt.Score,
                        UpdatedOn = evnt.Timestamp,
                        Version = evnt.Version,
                    }, new { Id = evnt.AggregateRootId, OrderCode = evnt.Order }, "Assesments", transaction);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }

        public void Handle(IHandlingContext context, AssessmentRecordCreated evnt)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    connection.Insert(new
                    {
                        Id = evnt.AggregateRootId,
                        OrderCode = evnt.Order,
                        Time = evnt.Time,
                        Type = evnt.Type,
                        Name = evnt.Name,
                        Score = evnt.Score,
                        IsDeleted = 0,
                        CreatedOn = evnt.Timestamp,
                        UpdatedOn = evnt.Timestamp,
                        Version = evnt.Version,
                    },"Assesments", transaction);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }

        public void Handle(IHandlingContext context, ControlTableItemUpdated evnt)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    connection.Update(new
                    {
                        Time = evnt.Time,
                        Type = evnt.Type,
                        Name = evnt.Name,
                        Content = evnt.Content,
                        Remark = evnt.Remark,
                        UpdatedOn = evnt.Timestamp,
                        Version = evnt.Version,
                    }, new { Id = evnt.AggregateRootId, OrderCode = evnt.Order }, "ControlTables", transaction);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
