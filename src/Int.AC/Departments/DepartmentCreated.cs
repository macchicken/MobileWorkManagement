using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Departments
{
    [Serializable]
    public class DepartmentCreated : DomainEvent<string>
    {
        public string Name { get; private set; }

        public string ParentId { get; private set; }

        public DepartmentCreated(string id, string name, string parentId)
            : base(id)
        {
            Name = name;
            ParentId = parentId;
        }
    }
}
