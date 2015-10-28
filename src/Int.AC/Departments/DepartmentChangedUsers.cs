using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Departments
{
    [Serializable]
    public class DepartmentChangedUsers : DomainEvent<string>
    {
        public string[] UserIds { get; private set; }

        public DepartmentChangedUsers(string id, string[] userIds)
            : base(id)
        {
            UserIds = userIds;
        }
    }
}
