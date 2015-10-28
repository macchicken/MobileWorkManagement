using ENode.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.Projects
{
    //项目命令聚合根，包含项目所有的属性和命令
        [Serializable]
        public class Project : AggregateRoot<string>
        {
            private string _username;
            private string _projectType;
            private DateTime _projectCreatedTime;
            private string _trainingTarget;

            private string _numOfPerson;

            private string _receivedTime;

            private string _days;

            private string _expectTime;

            private string _courseTitle;

            private string _projectContact;

            private bool _decision;

            private string _projectOrigin;

            private string _rival;

            private string _bid;

            private int _projectPossi;

            private string _cusProBudget;

            private string _projectEmergency;

            private string _courseSubject;

            private string _courseDetail;

            private string _courseOther;

            private string _rname;
            private string _area;
            private string _rTelephone;
            private string _rEmail;
            private string _cusBank;
            private string _cusMainBranch;
            private string _cusSubBranch;
            private string _cusContact;
            private string _cusTelephone;
            private string _cusEmail;
            private string _projectRtype;
            private string _requireDept;
            private string _duration;
            private string _relvant;

            private int _state;
            private int _prostate;
            private string _proposalOwner;
            private DateTime _proposalStart;

            private int _subsate;
            private string _subprocessTypeCode;
            private string _subprocesscontent;

            private string  _crorder;
            private string _crtime;
            private string _crtype;
            private string _crname;
            private string _crcontent;
            private string _crremark;


            private string _order;
            private string _time;
            private string _type;
            private string _name;
            private int _score;

            public Project(string id,string username, string projectType, DateTime projectCreatedTime)
                : base(id)
            {
                ApplyEvent(new ProjectFLowEvent(id, username, projectType, projectCreatedTime));
            }
            public void UpdateProjectFlow(string id,int state){
                ApplyEvent(new ProjectFlowUpdatedEvent(id, state));
            }

            public void AddTrainProject(string id, string trainingTarget, string numOfPerson, string receivedTime, string days, string expectTime, string courseTitle, string projectContact,
                bool decision,string projectOrigin,string rival,string bid,int projectPossi,string cusProBudget,string projectEmergency,
                string courseSubject,string courseDetail,string courseOther){
                    ApplyEvent(new TrainingStartedEvent(id, trainingTarget, numOfPerson, receivedTime, days, expectTime, courseDetail, projectContact, decision, projectOrigin, rival,
                        bid, projectPossi, cusProBudget, projectEmergency, courseSubject, courseDetail, courseOther));
            }
            public void UpdateTrain(string id, string trainingTarget, string numOfPerson, string receivedTime, string days, string expectTime, string courseTitle, string projectContact,
                bool decision, string projectOrigin, string rival, string bid, int projectPossi, string cusProBudget, string projectEmergency,
                string courseSubject, string courseDetail, string courseOther)
            {
                ApplyEvent(new TrainingUpdatedEvent(id, trainingTarget, numOfPerson, receivedTime, days, expectTime, courseDetail, projectContact, decision, projectOrigin, rival,
                        bid, projectPossi, cusProBudget, projectEmergency, courseSubject, courseDetail, courseOther));
            }
            public void AddConsultProject(string id, string rname, string area, string rTelephone, string rEmail, string cusBank, string cusMainBranch, string cusSubBranch,
                string cusContact, string cusTelephone, string cusEmail, string projectRtype, string requireDept, string duration, string relvant,
                string receivedTime, string expectTime, string projectContact, bool decision, string projectOrigin, string rival, string bid,
                int projectPossi, string cusProBudget, string projectEmergency, string courseSubject, string courseDetail, string courseOther)
            {
                ApplyEvent(new ConsultStartedEvent(id,rname, area, rTelephone, rEmail, cusBank, cusMainBranch, cusSubBranch, 
                    cusContact, cusTelephone, cusEmail, projectRtype, requireDept, duration, relvant,
                    receivedTime, expectTime, projectContact, decision, projectOrigin, rival, bid,
                    projectPossi, cusProBudget, projectEmergency, courseSubject, courseDetail, courseOther));
            }
            public void UpdateConsult(string id,string rname, string area, string rTelephone, string rEmail, string cusBank, string cusMainBranch, string cusSubBranch,
                string cusContact, string cusTelephone, string cusEmail, string projectRtype, string requireDept, string duration, string relvant,
                string receivedTime, string expectTime, string projectContact, bool decision, string projectOrigin, string rival, string bid,
                int projectPossi, string cusProBudget, string projectEmergency, string courseSubject, string courseDetail, string courseOther){
                    ApplyEvent(new ConsultUpdatedEvent(id, rname, area, rTelephone, rEmail, cusBank, cusMainBranch, cusSubBranch,
                        cusContact, cusTelephone, cusEmail, projectRtype, requireDept, duration, relvant,
                        receivedTime, expectTime, projectContact, decision, projectOrigin, rival, bid,
                        projectPossi, cusProBudget, projectEmergency, courseSubject, courseDetail, courseOther));
            }

            public void AddProposal(string id, int state, string proposalOwner, DateTime proposalStart)
            {
                ApplyEvent(new ProposalStartedEvent(id, state, proposalOwner, proposalStart));
            }
            public void UpdateProposal(string id, int state, string proposalOwner)
            {
                ApplyEvent(new ProposalUpdatedEvent(id,state,proposalOwner));
            }

            public void AddSubprocess(string id, string typecode,int substate, string content)
            {
                ApplyEvent(new SubprocessStartedEvent(id, typecode, substate, content));
            }
            public void UpdateSubprocess(string id, string typecode,int substate, string content)
            {
                ApplyEvent(new SubprocessUpdatedEvent(id,typecode,substate,content));
            }
            public void AddControlTableItem(string id, string order,string time, string type, string name, string content, string remark)
            {
                ApplyEvent(new ControlTableItemCreated(id,order,time,type,name,content,remark));
            }
            public void ModifyControlTableItem(string id, string order, string time, string type, string name, string content, string remark)
            {
                ApplyEvent(new ControlTableItemUpdated(id, order, time, type, name, content, remark));
            }

            public void CreateAssessmentRecord(string id, string order, string time, string type, string name, int score)
            {
                ApplyEvent(new AssessmentRecordCreated(id, order, time, type, name, score));
            }
            public void UpdateAssessmentRecord(string id, string order, string time, string type, string name, int score)
            {
                ApplyEvent(new AssessmentRecordUpdated(id, order, time, type, name, score));
            }

           

            private void Handle(ProjectFLowEvent evnt)
            {
                _id = evnt.AggregateRootId;
                _username = evnt.UserName;
                _projectType = evnt.ProjectType;
                _projectCreatedTime = evnt.ProjectCreatedTime;
            }
            private void Handle(ProjectFlowUpdatedEvent evnt)
            {
                _id = evnt.AggregateRootId;
                _state = evnt.State;
            }
            private void Handle(TrainingStartedEvent evnt)
            {
                _id = evnt.AggregateRootId;
                _trainingTarget = evnt.TrainingTarget;
                _numOfPerson = evnt.NumOfPerson;
                _receivedTime = evnt.ReceivedTime;
                _days = evnt.Days;
                _expectTime = evnt.ExpectTime;
                _courseTitle = evnt.CourseTitle;
                _projectContact = evnt.ProjectContact;
                _decision = evnt.Decision;
                _projectOrigin = evnt.ProjectOrigin;
                _rival = evnt.Rival;
                _bid = evnt.Bid;
                _projectPossi = evnt.ProjectPossi;
                _cusProBudget = evnt.CusProBudget;
                _projectEmergency = evnt.ProjectEmergency;
                _courseSubject = evnt.CourseSubject;
                _courseDetail = evnt.CourseDetail;
                _courseOther = evnt.CourseOther;
            }
            private void Handle(TrainingUpdatedEvent evnt)
            {
                _trainingTarget = evnt.TrainingTarget;
                _numOfPerson = evnt.NumOfPerson;
                _receivedTime = evnt.ReceivedTime;
                _days = evnt.Days;
                _expectTime = evnt.ExpectTime;
                _courseTitle = evnt.CourseTitle;
                _projectContact = evnt.ProjectContact;
                _decision = evnt.Decision;
                _projectOrigin = evnt.ProjectOrigin;
                _rival = evnt.Rival;
                _bid = evnt.Bid;
                _projectPossi = evnt.ProjectPossi;
                _cusProBudget = evnt.CusProBudget;
                _projectEmergency = evnt.ProjectEmergency;
                _courseSubject = evnt.CourseSubject;
                _courseDetail = evnt.CourseDetail;
                _courseOther = evnt.CourseOther;
            }
            private void Handle(ConsultStartedEvent evnt)
            {
                _id = evnt.AggregateRootId;
                _rname = evnt.Rname;
                _area = evnt.Area;
                _rTelephone = evnt.RTelephone;
                _rEmail = evnt.REmail;
                _cusBank = evnt.CusBank;
                _cusMainBranch = evnt.CusMainBranch;
                _cusSubBranch = evnt.CusSubBranch;
                _cusContact = evnt.CusContact;
                _cusTelephone = evnt.CusTelephone;
                _cusEmail = evnt.CusEmail;
                _projectRtype = evnt.ProjectRtype;
                _requireDept = evnt.RequireDept;
                _duration = evnt.Duration;
                _relvant = evnt.Relvant;
                _receivedTime = evnt.ReceivedTime;
                _expectTime = evnt.ExpectTime;
                _projectContact = evnt.ProjectContact;
                _decision = evnt.Decision;
                _projectOrigin = evnt.ProjectOrigin;
                _rival = evnt.Rival;
                _bid = evnt.Bid;
                _projectPossi = evnt.ProjectPossi;
                _cusProBudget = evnt.CusProBudget;
                _projectEmergency = evnt.ProjectEmergency;
                _courseSubject = evnt.CourseSubject;
                _courseDetail = evnt.CourseDetail;
                _courseOther = evnt.CourseOther;
            }
            private void Handle(ConsultUpdatedEvent evnt)
            {
                _rname = evnt.Rname;
                _area = evnt.Area;
                _rTelephone = evnt.RTelephone;
                _rEmail = evnt.REmail;
                _cusBank = evnt.CusBank;
                _cusMainBranch = evnt.CusMainBranch;
                _cusSubBranch = evnt.CusSubBranch;
                _cusContact = evnt.CusContact;
                _cusTelephone = evnt.CusTelephone;
                _cusEmail = evnt.CusEmail;
                _projectRtype = evnt.ProjectRtype;
                _requireDept = evnt.RequireDept;
                _duration = evnt.Duration;
                _relvant = evnt.Relvant;
                _receivedTime = evnt.ReceivedTime;
                _expectTime = evnt.ExpectTime;
                _projectContact = evnt.ProjectContact;
                _decision = evnt.Decision;
                _projectOrigin = evnt.ProjectOrigin;
                _rival = evnt.Rival;
                _bid = evnt.Bid;
                _projectPossi = evnt.ProjectPossi;
                _cusProBudget = evnt.CusProBudget;
                _projectEmergency = evnt.ProjectEmergency;
                _courseSubject = evnt.CourseSubject;
                _courseDetail = evnt.CourseDetail;
                _courseOther = evnt.CourseOther;
            }

            private void Handle(ProposalStartedEvent evnt)
            {
                _id = evnt.AggregateRootId;
                _prostate = evnt.State;
                _proposalOwner = evnt.ProposalOwner;
                _proposalStart = evnt.ProposalStart;
            }
            private void Handle(ProposalUpdatedEvent evnt)
            {
                _id = evnt.AggregateRootId;
                _prostate = evnt.State;
                _proposalOwner = evnt.ProposalOwner;
            }

            private void Handle(SubprocessStartedEvent evnt)
            {
                _id = evnt.AggregateRootId;
                _subprocessTypeCode = evnt.TypeCode;
                _subsate = evnt.State;
                _subprocesscontent = evnt.Content;
            }
            private void Handle(SubprocessUpdatedEvent evnt)
            {
                _id = evnt.AggregateRootId;
                _subprocessTypeCode = evnt.TypeCode;
                _subsate = evnt.State;
                _subprocesscontent = evnt.Content;
            }

            private void Handle(ControlTableItemCreated evnt)
            {
                _id = evnt.AggregateRootId;
                _crorder = evnt.Order;
                _crtime = evnt.Time;
                _crtype = evnt.Type;
                _crname = evnt.Name;
                _crcontent = evnt.Content;
                _crremark = evnt.Remark;
            }
            private void Handle(ControlTableItemUpdated evnt)
            {
                _id = evnt.AggregateRootId;
                _crorder = evnt.Order;
                _crtime = evnt.Time;
                _crtype = evnt.Type;
                _crname = evnt.Name;
                _crcontent = evnt.Content;
                _crremark = evnt.Remark;
            }
            private void Handle(AssessmentRecordCreated evnt)
            {
                _id = evnt.AggregateRootId;
                _order = evnt.Order;
                _time = evnt.Time;
                _type = evnt.Type;
                _name = evnt.Name;
                _score = evnt.Score;
            }
            private void Handle(AssessmentRecordUpdated evnt)
            {
                _id = evnt.AggregateRootId;
                _order = evnt.Order;
                _time=evnt.Time;
                _type=evnt.Type;
                _name=evnt.Name;
                _score=evnt.Score;
            }
        }

}
