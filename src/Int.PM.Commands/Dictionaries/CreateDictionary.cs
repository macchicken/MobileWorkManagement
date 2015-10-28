using ECommon.Utilities;
using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.Commands.Dictionaries
{
    [Serializable]
    public class CreateDictionary : AggregateCommand<string>, ICreatingAggregateCommand
    {
        public string Name { get; private set; }

        public string ParentId { get; private set; }

        public int Type { get; private set; }

        public CreateDictionary(string name, string parentId, int type)
        {
            AggregateRootId = ObjectId.GenerateNewStringId();
            Name = name;
            ParentId = parentId;
            Type = type;
        }
    }
}
