using ECommon.Utilities;
using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Commands.Departments
{
    [Serializable]
    public class CreateDepartment : AggregateCommand<string>, ICreatingAggregateCommand
    {
        public string Name { get; private set; }

        public string ParentId { get; private set; }

        public CreateDepartment(string id, string name, string parentId = null)
        {
            AggregateRootId = id; 
            Name = name;
            ParentId = parentId;
        }
    }
}
