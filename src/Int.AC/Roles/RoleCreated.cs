using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Roles
{
    [Serializable]
    public class RoleCreated : DomainEvent<string>
    {
        public string Name { get; private set; }

        public int Sort { get; private set; }

        public RoleCreated(string id, string name, int sort)
            : base(id)
        {
            Name = name;
            Sort = sort;
        }
    }
}
