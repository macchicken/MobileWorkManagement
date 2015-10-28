using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.Commands.Projects
{
    [Serializable]
    public class UpdateProjectFlow: AggregateCommand<string>
    {
        public int State { get; private set; }

        public UpdateProjectFlow(string id, int state)
            : base(id)
        {
            State = state;
        }
    }
}
