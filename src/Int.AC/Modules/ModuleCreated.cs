using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Modules
{
    [Serializable]
    public class ModuleCreated : DomainEvent<string>
    {
        public string ServiceId { get; private set; }

        public string Code { get; private set; }

        public string Text { get; private set; }

        public string ParentId { get; private set; }

        public int Sort { get; private set; }

        public ModuleCreated(string id, string serviceId, string code, string text, string parentId, int sort)
            : base(id)
        {
            ServiceId = serviceId;
            Code = code;
            Text = text;
            ParentId = parentId;
            Sort = sort;
        }
    }
}
