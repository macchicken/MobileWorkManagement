using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Commands.Roles
{
    [Serializable]
    public class UpdateRole : AggregateCommand<string>
    {
        public string Name { get; private set; }

        public int Sort { get; private set; }

        public bool UseAble { get; private set; }

        public UpdateRole(string id, string name, int sort, bool useAble)
            : base(id) 
        {
            Name = name;
            Sort = sort;
            UseAble = useAble;
        }
    }
}
