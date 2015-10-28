using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Commands.Modules
{
    [Serializable]
    public class UpdateModule : AggregateCommand<string>
    {
        public string Code { get; private set; }

        public string Text { get; private set; }

        public string ParentId { get; private set; }

        public int Sort { get; private set; }

        public bool UseAble { get; private set; }

        public UpdateModule(string id, string code, string text, string parentId, int sort, bool useAble)
            : base(id) 
        {
            Code = code;
            Text = text;
            ParentId = parentId;
            Sort = sort;
            UseAble = useAble;
        }
    }
}
