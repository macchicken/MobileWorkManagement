using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Commands.Roles
{
    [Serializable]
    public class SetRolePermissions : AggregateCommand<string>
    {
        public string[] PermissionIds { get; private set; }

        public SetRolePermissions(string id, string[] permissionIds)
            : base(id) 
        {
            PermissionIds = permissionIds;
        }
    }
}
