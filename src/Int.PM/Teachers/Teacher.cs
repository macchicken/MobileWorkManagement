using ENode.Domain;
using Int.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.Teachers
{
    [Serializable]
    public class Teacher : AggregateRoot<string>
    {
        public string _name;
        public string _sex;
        public string _age;
        public string _source;
        public string _isInOffice;
        public DateTime? _leaveOfficeTime;
        public string _seniority;
        public int _workingTimePlan;
        public string _province;
        public string _city;
        public string _officePhone;
        public string _personalCall;
        public string _email;
        public string _qqMsn;
        public string _linkMan;
        public string _linkPhone;
        public string _linkEmail;
        public int _signingType;
        public string _contractNo;
        public string _workExperiences;
        public string _teachExperiences;
        public string _eduExperience;
        public string _specialty;
        public string _promoteMan;
        public string _promotePhone;
        public int _price;
        public string _remark;
        public int _teamType;
        public string[] _tags;
        public string[] _territories;
        public string[] _industries;

        public Teacher(string id, string name, string sex, string source, string seniority, string officePhone,
            string personalCall, string email, string specialty, string promoteMan, string promotePhone, int teamType, string[] tags)
            : base(id)
        {
            Assert.IsNotNullOrWhiteSpace("老师ID", id);
            ApplyEvent(new TeacherCreated(id, name, sex, source, seniority, officePhone, personalCall, email,
                specialty, promoteMan, promotePhone, teamType, tags));
        }

        public void Update(string name, string sex, string source,   string seniority, string officePhone, 
            string personalCall, string email, string specialty,  string promoteMan,  string promotePhone, int teamType, string[] tags)
        {
            ApplyEvent(new TeacherUpdated(Id, name, sex, source, seniority, officePhone, personalCall, email,
                specialty, promoteMan, promotePhone, teamType, tags));
        }

        public void ChangeDetail(string age, string isInOffice, DateTime? leaveOfficeTime, int workingTimePlan, string province,
            string city, string qqMsn, string linkMan, string linkPhone, string linkEmail, int signingType, string workExperiences, string teachExperiences,
            string eduExperience, int price, string remark, string[] territories, string[] industries)
        {
            ApplyEvent(new TeacherChangedDetail(Id, age, isInOffice, leaveOfficeTime, workingTimePlan, province,
            city, qqMsn, linkMan, linkPhone, linkEmail, signingType, workExperiences, teachExperiences,
            eduExperience, price, remark, territories, industries));
        }

        private void Handle(TeacherCreated evnt)
        {
            _id = evnt.AggregateRootId;
            _name = evnt.Name;
            _sex = evnt.Sex;
            _source = evnt.Source;
            _seniority = evnt.Seniority;
            _officePhone = evnt.OfficePhone;
            _personalCall = evnt.PersonalCall;
            _email = evnt.Email;
            _specialty = evnt.Specialty;
            _promoteMan = evnt.PromoteMan;
            _promotePhone = evnt.PromotePhone;
            _teamType = evnt.TeamType;
            _tags = evnt.Tags;
        }
        private void Handle(TeacherUpdated evnt)
        {
            _name = evnt.Name;
            _sex = evnt.Sex;
            _source = evnt.Source;
            _seniority = evnt.Seniority;
            _officePhone = evnt.OfficePhone;
            _personalCall = evnt.PersonalCall;
            _email = evnt.Email;
            _specialty = evnt.Specialty;
            _promoteMan = evnt.PromoteMan;
            _promotePhone = evnt.PromotePhone;
            _teamType = evnt.TeamType;
            _tags = evnt.Tags;
        }
        private void Handle(TeacherChangedDetail evnt)
        {
            _age = evnt.Age;
            _isInOffice = evnt.IsInOffice;
            _leaveOfficeTime = evnt.LeaveOfficeTime;
            _workingTimePlan = evnt.WorkingTimePlan;
            _province = evnt.Province;
            _city = evnt.City;
            _qqMsn = evnt.QQMsn;
            _linkMan = evnt.LinkMan;
            _linkPhone = evnt.LinkPhone;
            _linkEmail = evnt.LinkEmail;
            _signingType = evnt.SigningType;
            _workExperiences = evnt.WorkExperiences;
            _teachExperiences = evnt.TeachExperiences;
            _eduExperience = evnt.EduExperience;
            _price = evnt.Price;
            _remark = evnt.Remark;
            _territories = evnt.Territories;
            _industries = evnt.Industries;
        }
    }
}
