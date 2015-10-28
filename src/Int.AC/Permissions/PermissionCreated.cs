using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Permissions
{
    [Serializable]
    public class PermissionCreated : DomainEvent<string>
    {
        public string Code { get; private set; }

        public string Name { get; private set; }

        public string ModuleId { get; private set; }

        public PermissionCreated(string id, string code, string name, string moduleId)
            : base(id)
        {
            Code = code;
            Name = name;
            ModuleId = moduleId;
        }
    }
}
