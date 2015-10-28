using ECommon.Utilities;
using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Commands.Roles
{
    [Serializable]
    public class CreateRole : AggregateCommand<string>, ICreatingAggregateCommand
    {
        public string Name { get; private set; }

        public int Sort { get; private set; }

        public CreateRole(string name, int sort)
        {
            AggregateRootId = ObjectId.GenerateNewStringId();
            Name = name;
            Sort = sort;
        }
    }
}
