using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Roles
{
    [Serializable]
    public class RoleUpdated : DomainEvent<string>
    {
        public string Name { get; private set; }

        public int Sort { get; private set; }

        public bool UseAble { get; private set; }

        public RoleUpdated(string id, string name, int sort, bool useAble)
            : base(id)
        {
            Name = name;
            Sort = sort;
            UseAble = useAble;
        }
    }
}
