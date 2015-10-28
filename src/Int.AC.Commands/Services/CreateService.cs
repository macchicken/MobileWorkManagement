using ECommon.Utilities;
using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Commands.Services
{
    [Serializable]
    public class CreateService : AggregateCommand<string>, ICreatingAggregateCommand
    {
        public string Name { get; private set; }

        public int Sort { get; private set; }

        public string Url { get; private set; }

        public CreateService(string id, string name, int sort, string url)
        {
            AggregateRootId = id;
            Name = name;
            Sort = sort;
            Url = url;
        }
    }
}
