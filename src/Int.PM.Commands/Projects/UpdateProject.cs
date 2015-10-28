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
    public class UpdateTrainingProject : AggregateCommand<string>
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

        public UpdateTrainingProject(string id, string trainingTarget, string numOfPerson, string receivedTime, string days, string expectTime, string courseTitle,
            string projectContact, bool decision, string projectOrigin, string rival, string bid,
            int projectPossi, string cusProBudget, string projectEmergency, string courseSubject, string courseDetail, string courseOther):base(id)
        {
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
    public class UpdateConsultProject : AggregateCommand<string>
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
        public UpdateConsultProject(string id,string rname, string area, string rTelephone, string rEmail, string cusBank, string cusMainBranch, string cusSubBranch,
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
}
