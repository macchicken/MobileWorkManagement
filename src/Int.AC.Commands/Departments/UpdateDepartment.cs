using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Commands.Departments
{
    [Serializable]
    public class UpdateDepartment : AggregateCommand<string>
    {
        public string Name { get; private set; }
        public string ParentId { get; private set; }

        public UpdateDepartment(string id, string name, string parentId)
            : base(id)
        {
            Name = name;
            ParentId = parentId;
        }
    }
}
