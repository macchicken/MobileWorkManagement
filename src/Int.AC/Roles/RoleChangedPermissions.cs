using ENode.Commanding;
using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Roles
{
    [Serializable]
    public class RoleChangedPermissions : DomainEvent<string>
    {
        public string[] PermissionIds { get; private set; }

        public RoleChangedPermissions(string id, string[] permissionIds)
            : base(id) 
        {
            PermissionIds = permissionIds;
        }
    }
}
