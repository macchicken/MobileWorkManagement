using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.Commands.Projects
{
    [Serializable]
    public class UpdateSubProcess : AggregateCommand<string>
    {
        public string TypeCode { get; private set; }
        public int State { get; private set; }
        public string Content { get; private set; }

        public UpdateSubProcess(string id, string typeCode, int state, string content)
            : base(id)
        {
            TypeCode = typeCode;
            State = state;
            Content = content;
        }
    }
}
