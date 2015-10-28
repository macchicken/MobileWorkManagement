using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Commands.Users
{
    [Serializable]
    public class UpdateUser : AggregateCommand<string>
    {
        public string Code { get; private set; }

        public string Name { get; private set; }

        public string NameEn { get; private set; }

        public string Email { get; private set; }

        public string Phone { get; private set; }

        public string JobName { get; private set; }

        public string LeaderId { get; private set; }

        public bool UseAble { get; private set; }

        public string[] Departments { get; private set; }

        public UpdateUser(string id, string code, string name, string nameEn,
            string email, string phone, string jobName, string leaderId, bool useAble, string[] departments = null)
            : base(id) 
        {
            Code = code;
            Name = name;
            NameEn = nameEn;
            Email = email;
            Phone = phone;
            JobName = jobName;
            LeaderId = leaderId;
            UseAble = useAble;
            Departments = departments;
        }
    }
}
