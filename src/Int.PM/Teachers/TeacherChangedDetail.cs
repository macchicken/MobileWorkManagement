using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.Teachers
{
    [Serializable]
    public class TeacherChangedDetail : DomainEvent<string>
    {
        /// <summary>
        /// 年龄段
        /// </summary>
        public string Age { get; private set; }

        public string IsInOffice { get; private set; }

        public DateTime? LeaveOfficeTime { get; private set; }

        /// <summary>
        /// 工作时间计划
        /// </summary>
        public int WorkingTimePlan { get; private set; }

        /// <summary>
        /// 所在省份
        /// </summary>
        public string Province { get; private set; }

        /// <summary>
        /// 所在城市
        /// </summary>
        public string City { get; private set; }

        public string QQMsn { get; private set; }

        public string LinkMan { get; private set; }

        public string LinkPhone { get; private set; }

        public string LinkEmail { get; private set; }

        /// <summary>
        /// 签约情况
        /// </summary>
        public int SigningType { get; private set; }

        /// <summary>
        /// 工作经历
        /// </summary>
        public string WorkExperiences { get; private set; }

        /// <summary>
        /// 授课/咨询经历
        /// </summary>
        public string TeachExperiences { get; private set; }

        /// <summary>
        /// 教育经历
        /// </summary>
        public string EduExperience { get; private set; }


        /// <summary>
        /// 价钱
        /// </summary>
        public int Price { get; private set; }

        public string Remark { get; private set; }

        /// <summary>
        /// 专攻领域
        /// </summary>
        public string[] Territories { get; private set; }

        /// <summary>
        /// 行业
        /// </summary>
        public string[] Industries { get; private set; }

        public TeacherChangedDetail(string id, string age, string isInOffice, DateTime? leaveOfficeTime, int workingTimePlan, string province,
            string city, string qqMsn, string linkMan, string linkPhone, string linkEmail, int signingType, string workExperiences, string teachExperiences,
            string eduExperience, int price, string remark, string[] territories, string[] industries)
            : base(id) 
        {
            Age = age;
            IsInOffice = isInOffice;
            LeaveOfficeTime = leaveOfficeTime;
            WorkingTimePlan = workingTimePlan;
            Province = province;
            City = city;
            QQMsn = qqMsn;
            LinkMan = linkMan;
            LinkPhone = linkPhone;
            LinkEmail = linkEmail;
            SigningType = signingType;
            WorkExperiences = workExperiences;
            TeachExperiences = teachExperiences;
            EduExperience = eduExperience;
            Price = price;
            Remark = remark;
            Territories = territories;
            Industries = industries;
        }
    }
}
