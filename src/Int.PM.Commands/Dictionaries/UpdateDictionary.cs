using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.Commands.Dictionaries
{
    [Serializable]
    public class UpdateDictionary : AggregateCommand<string>
    {
        public string Name { get; private set; }

        public string ParentId { get; private set; }

        public int Type { get; private set; }

        public UpdateDictionary(string id, string name, string parentId, int type)
            : base(id)
        {
            Name = name;
            ParentId = parentId;
            Type = type;
        }
    }
}
