using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Commands.Users
{
    [Serializable]
    public class SetUserRoles : AggregateCommand<string>
    {
        public string[] RoleIds { get; private set; }

        public SetUserRoles(string id, string[] roleIds)
            : base(id) 
        {
            RoleIds = roleIds;
        }
    }
}
