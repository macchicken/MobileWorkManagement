using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Users
{
    [Serializable]
    public class UserChangedRoles : DomainEvent<string>
    {
        public string[] RoleIds { get; private set; }

        public UserChangedRoles(string id, string[] roleIds)
            : base(id) 
        {
            RoleIds = roleIds;
        }
    }
}
