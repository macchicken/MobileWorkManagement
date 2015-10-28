using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.Commands.Teachers
{
    [Serializable]
    public class UpdateTeacher : AggregateCommand<string>
    {
        public string Name { get; private set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; private set; }

        public string Source { get; private set; }

        /// <summary>
        /// 年资
        /// </summary>
        public string Seniority { get; private set; }

        public string OfficePhone { get; private set; }

        public string PersonalCall { get; private set; }

        public string Email { get; private set; }

        /// <summary>
        /// 特长
        /// </summary>
        public string Specialty { get; private set; }

        /// <summary>
        /// 推介人
        /// </summary>
        public string PromoteMan { get; private set; }
        public string PromotePhone { get; private set; }

        public int TeamType { get; private set; }
        public string[] Tags { get; private set; }

        public UpdateTeacher(string id, string name, string sex, string source, string seniority, string officePhone,
            string personalCall, string email, string specialty, string promoteMan, string promotePhone, int teamType, string[] tags)
            : base(id) 
        {
            Name = name;
            Sex = sex;
            Source = source;
            Seniority = seniority;
            OfficePhone = officePhone;
            PersonalCall = personalCall;
            Email = email;
            Specialty = specialty;
            PromoteMan = promoteMan;
            PromotePhone = promotePhone;
            TeamType = teamType;
            Tags = tags;
        }
    }
}
