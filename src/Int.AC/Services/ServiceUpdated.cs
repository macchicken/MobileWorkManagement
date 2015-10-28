using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Services
{
    [Serializable]
    public class ServiceUpdated : DomainEvent<string>
    {
        public string Name { get; private set; }

        public int Sort { get; private set; }

        public string Url { get; private set; }

        public ServiceUpdated(string id,  string name, int sort, string url)
            : base(id)
        {
            Name = name;
            Sort = sort;
            Url = url;
        }
    }
}
