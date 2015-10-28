using ECommon.Utilities;
using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Commands.Users
{
    [Serializable]
    public class CreateUser : AggregateCommand<string>, ICreatingAggregateCommand
    {
        public string Code { get; private set; }

        public string Name { get; private set; }

        public string NameEn { get; private set; }

        public string Email { get; private set; }

        public string Phone { get; private set; }

        public string JobName { get; private set; }

        public string LeaderId { get; private set; }

        public string[] Departments { get; private set; }

        public CreateUser(string code, string name, string nameEn,
            string email, string phone, string jobName, string leaderId = null, string[] departments = null)
        {
            AggregateRootId = ObjectId.GenerateNewStringId(); 
            Code = code;
            Name = name;
            NameEn = nameEn;
            Email = email;
            Phone = phone;
            JobName = jobName;
            if(!string.IsNullOrWhiteSpace(leaderId))
                LeaderId = leaderId;
            Departments = departments;
        }
    }
}
