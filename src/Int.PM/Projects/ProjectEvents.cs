using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.Projects
{

    [Serializable]
    public class ProjectFLowEvent : DomainEvent<string>
    {
        public string UserName { get; private set; }
        public string ProjectType { get; private set; }
        public DateTime ProjectCreatedTime { get; private set; }

        public ProjectFLowEvent(string id, string userName, string projectType, DateTime projectCreatedTime)
            : base(id)
        {
            UserName = userName;
            ProjectType = projectType;
            ProjectCreatedTime = projectCreatedTime;
        }
    }
    [Serializable]
    public class ProjectFlowUpdatedEvent : DomainEvent<string>
    {
        public int State { get; private set; }

        public ProjectFlowUpdatedEvent(string id, int state):base(id)
        {
            State = state;
        }
    }

    [Serializable]
    public class ProposalStartedEvent : DomainEvent<string>
    {
        public int State { get; private set; }
        public string ProposalOwner { get; private set; }
        public DateTime ProposalStart { get; private set; }

        public ProposalStartedEvent(string id, int state, string proposalOwner, DateTime proposalStart)
            : base(id)
        {
            State = state;
            ProposalOwner = proposalOwner;
            ProposalStart = proposalStart;
        }
    }

    [Serializable]
    public class ProposalUpdatedEvent : DomainEvent<string>
    {
        public int State { get; private set; }
        public string ProposalOwner { get; private set; }

        public ProposalUpdatedEvent(string id, int state, string proposalOwner):base(id)
        {
            State = state;
            ProposalOwner = proposalOwner;
        }
    }

    [Serializable]
    public class TrainingStartedEvent : DomainEvent<string>
    {
        public string TrainingTarget { get; private set; }

        public string NumOfPerson { get; private set; }

        public string ReceivedTime { get; private set; }

        public string Days { get; private set; }

        public string ExpectTime { get; private set; }

        public string CourseTitle { get; private set; }

        public string ProjectContact { get; private set; }

        public bool Decision { get; private set; }

        public string ProjectOrigin { get; private set; }

        public string Rival { get; private set; }

        public string Bid { get; private set; }

        public int ProjectPossi { get; private set; }

        public string CusProBudget { get; private set; }

        public string ProjectEmergency { get; private set; }

        public string CourseSubject { get; private set; }

        public string CourseDetail { get; private set; }

        public string CourseOther { get; private set; }

        public TrainingStartedEvent(string id, string trainingTarget, string numOfPerson, string receivedTime, string days, string expectTime, string courseTitle,
            string projectContact ,bool decision ,string projectOrigin ,string rival ,string bid ,
            int projectPossi ,string cusProBudget ,string projectEmergency ,string courseSubject ,string courseDetail ,string courseOther):base(id){
                TrainingTarget = trainingTarget;
                NumOfPerson = numOfPerson;
                ReceivedTime = receivedTime;
                Days = days;
                ExpectTime = expectTime;
                CourseTitle = courseTitle;
                ProjectContact = projectContact;
                Decision = decision;
                ProjectOrigin = projectOrigin;
                Rival = rival;
                Bid = bid;
                ProjectPossi = projectPossi;
                CusProBudget = cusProBudget;
                ProjectEmergency = projectEmergency;
                CourseSubject = courseSubject;
                CourseDetail = courseDetail;
                CourseOther = courseOther;
        }
    }
    [Serializable]
    public class TrainingUpdatedEvent : DomainEvent<string>
    {
        public string TrainingTarget { get; private set; }
        public string NumOfPerson { get; private set; }

        public string ReceivedTime { get; private set; }

        public string Days { get; private set; }

        public string ExpectTime { get; private set; }

        public string CourseTitle { get; private set; }

        public string ProjectContact { get; private set; }

        public bool Decision { get; private set; }

        public string ProjectOrigin { get; private set; }

        public string Rival { get; private set; }

        public string Bid { get; private set; }

        public int ProjectPossi { get; private set; }

        public string CusProBudget { get; private set; }

        public string ProjectEmergency { get; private set; }

        public string CourseSubject { get; private set; }

        public string CourseDetail { get; private set; }

        public string CourseOther { get; private set; }
        public TrainingUpdatedEvent(string id, string trainingTarget, string numOfPerson, string receivedTime, string days, string expectTime, string courseTitle,
            string projectContact ,bool decision ,string projectOrigin ,string rival ,string bid ,
            int projectPossi ,string cusProBudget ,string projectEmergency ,string courseSubject ,string courseDetail ,string courseOther):base(id){
                TrainingTarget = trainingTarget;
                NumOfPerson = numOfPerson;
                ReceivedTime = receivedTime;
                Days = days;
                ExpectTime = expectTime;
                CourseTitle = courseTitle;
                ProjectContact = projectContact;
                Decision = decision;
                ProjectOrigin = projectOrigin;
                Rival = rival;
                Bid = bid;
                ProjectPossi = projectPossi;
                CusProBudget = cusProBudget;
                ProjectEmergency = projectEmergency;
                CourseSubject = courseSubject;
                CourseDetail = courseDetail;
                CourseOther = courseOther;
        }
    }
    [Serializable]
    public class ConsultStartedEvent : DomainEvent<string>
    {
        public string Rname { get; private set; }
        public string Area { get; private set; }
        public string RTelephone { get; private set; }
        public string REmail { get; private set; }
        public string CusBank { get; private set; }
        public string CusMainBranch { get; private set; }
        public string CusSubBranch { get; private set; }
        public string CusContact { get; private set; }
        public string CusTelephone { get; private set; }
        public string CusEmail { get; private set; }
        public string ProjectRtype { get; private set; }
        public string RequireDept { get; private set; }
        public string Duration { get; private set; }
        public string Relvant { get; private set; }
        public string ReceivedTime { get; private set; }
        public string ExpectTime { get; private set; }
        public string ProjectContact { get; private set; }

        public bool Decision { get; private set; }

        public string ProjectOrigin { get; private set; }

        public string Rival { get; private set; }

        public string Bid { get; private set; }

        public int ProjectPossi { get; private set; }

        public string CusProBudget { get; private set; }

        public string ProjectEmergency { get; private set; }

        public string CourseSubject { get; private set; }

        public string CourseDetail { get; private set; }

        public string CourseOther { get; private set; }

        public ConsultStartedEvent(string id,string rname, string area, string rTelephone, string rEmail, string cusBank, string cusMainBranch, string cusSubBranch,
            string cusContact, string cusTelephone, string cusEmail, string projectRtype, string requireDept, string duration, string relvant,
            string receivedTime, string expectTime, string projectContact, bool decision, string projectOrigin, string rival, string bid,
            int projectPossi, string cusProBudget, string projectEmergency, string courseSubject, string courseDetail, string courseOther):base(id)
        {
            Rname=rname;
            Area=area;
            RTelephone=rTelephone;
            REmail=rEmail;
            CusBank=cusBank;
            CusMainBranch=cusMainBranch;
            CusSubBranch=cusSubBranch;
            CusContact=cusContact;
            CusTelephone=cusTelephone;
            CusEmail=cusEmail;
            ProjectRtype=projectRtype;
            RequireDept=requireDept;
            Duration = duration;
            Relvant = relvant;
            ReceivedTime = receivedTime;
            ExpectTime = expectTime;
            ProjectContact = projectContact;
            Decision = decision;
            ProjectOrigin = projectOrigin;
            Rival = rival;
            Bid = bid;
            ProjectPossi = projectPossi;
            CusProBudget = cusProBudget;
            ProjectEmergency = projectEmergency;
            CourseSubject = courseSubject;
            CourseDetail = courseDetail;
            CourseOther = courseOther;
        }
     }
    [Serializable]
    public class ConsultUpdatedEvent : DomainEvent<string>
    {
        public string Rname { get; private set; }
        public string Area { get; private set; }
        public string RTelephone { get; private set; }
        public string REmail { get; private set; }
        public string CusBank { get; private set; }
        public string CusMainBranch { get; private set; }
        public string CusSubBranch { get; private set; }
        public string CusContact { get; private set; }
        public string CusTelephone { get; private set; }
        public string CusEmail { get; private set; }
        public string ProjectRtype { get; private set; }
        public string RequireDept { get; private set; }
        public string Duration { get; private set; }
        public string Relvant { get; private set; }
        public string ReceivedTime { get; private set; }
        public string ExpectTime { get; private set; }
        public string ProjectContact { get; private set; }

        public bool Decision { get; private set; }

        public string ProjectOrigin { get; private set; }

        public string Rival { get; private set; }

        public string Bid { get; private set; }

        public int ProjectPossi { get; private set; }

        public string CusProBudget { get; private set; }

        public string ProjectEmergency { get; private set; }

        public string CourseSubject { get; private set; }

        public string CourseDetail { get; private set; }

        public string CourseOther { get; private set; }

        public ConsultUpdatedEvent(string id,string rname, string area, string rTelephone, string rEmail, string cusBank, string cusMainBranch, string cusSubBranch,
            string cusContact, string cusTelephone, string cusEmail, string projectRtype, string requireDept, string duration, string relvant,
            string receivedTime, string expectTime, string projectContact, bool decision, string projectOrigin, string rival, string bid,
            int projectPossi, string cusProBudget, string projectEmergency, string courseSubject, string courseDetail, string courseOther):base(id)
        {
            Rname = rname;
            Area = area;
            RTelephone = rTelephone;
            REmail = rEmail;
            CusBank = cusBank;
            CusMainBranch = cusMainBranch;
            CusSubBranch = cusSubBranch;
            CusContact = cusContact;
            CusTelephone = cusTelephone;
            CusEmail = cusEmail;
            ProjectRtype = projectRtype;
            RequireDept = requireDept;
            Duration = duration;
            Relvant = relvant;
            ReceivedTime = receivedTime;
            ExpectTime = expectTime;
            ProjectContact = projectContact;
            Decision = decision;
            ProjectOrigin = projectOrigin;
            Rival = rival;
            Bid = bid;
            ProjectPossi = projectPossi;
            CusProBudget = cusProBudget;
            ProjectEmergency = projectEmergency;
            CourseSubject = courseSubject;
            CourseDetail = courseDetail;
            CourseOther = courseOther;
        }
    }
    [Serializable]
    public class SubprocessStartedEvent : DomainEvent<string>
    {
        public string TypeCode { get; set; }
        public int State { get; private set; }
        public string Content { get; private set; }

        public SubprocessStartedEvent(string id, string typeCode,int state, string content):base(id)
        {
            TypeCode = typeCode;
            State = state;
            Content = content;
        }
    }
    [Serializable]
    public class SubprocessUpdatedEvent : DomainEvent<string>
    {
        public string TypeCode { get; set; }
        public int State { get; private set; }
        public string Content { get; private set; }

        public SubprocessUpdatedEvent(string id, string typeCode, int state, string content)
            : base(id)
        {
            TypeCode = typeCode;
            State = state;
            Content = content;
        }
    }

    [Serializable]
    public class ControlTableItemCreated : DomainEvent<string>
    {
        public string Order { get; private set; }//item的序号
        public string Time { get; private set; }//item的日期
        public string Type { get; private set; }//item的类型
        public string Name { get; private set; }//item的名称
        public string Content { get; private set; }//内容
        public string Remark { get; private set; }//补充

        public ControlTableItemCreated(string id, string order, string time, string type, string name, string content, string remark)
            : base(id)
        {
            Order = order;
            Time = time;
            Type = type;
            Name = name;
            Content = content;
            Remark = remark;
        }
    }
    [Serializable]
    public class ControlTableItemUpdated : DomainEvent<string>
    {
        public string Order { get; private set; }//item的序号
        public string Time { get; private set; }//item的日期
        public string Type { get; private set; }//item的类型
        public string Name { get; private set; }//item的名称
        public string Content { get; private set; }//内容
        public string Remark { get; private set; }//补充

        public ControlTableItemUpdated(string id, string order, string time, string type, string name, string content, string remark)
            : base(id)
        {
            Order = order;
            Time = time;
            Type = type;
            Name = name;
            Content = content;
            Remark = remark;
        }
    }

    [Serializable]
    public class AssessmentRecordUpdated : DomainEvent<string>
    {
        public string Order { get; private set; }
        public string Time { get; private set; }
        public string Type { get; private set; }
        public string Name { get; private set; }
        public int Score { get; private set; }

        public AssessmentRecordUpdated(string id, string order, string time, string type, string name, int score)
            : base(id)
        {
            Order = order;
            Time = time;
            Type = type;
            Name = name;
            Score = score;
        }
    }
    [Serializable]
    public class AssessmentRecordCreated : DomainEvent<string>
    {
        public string Order { get; private set; }
        public string Time { get; private set; }
        public string Type { get; private set; }
        public string Name { get; private set; }
        public int Score { get; private set; }

        public AssessmentRecordCreated(string id, string order, string time, string type, string name, int score)
            : base(id)
        {
            Order = order;
            Time = time;
            Type = type;
            Name = name;
            Score = score;
        }
    }
}
