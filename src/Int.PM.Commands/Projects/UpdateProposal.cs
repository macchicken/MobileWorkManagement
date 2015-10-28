using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.Commands.Projects
{
    [Serializable]
    public class UpdateProposal : AggregateCommand<string>
    {
        public int State { get; private set; }
        public string ProposalOwner { get; private set; }

        public UpdateProposal(string id,int state, string proposalOwner):base(id)
        {
            State = state;
            ProposalOwner = proposalOwner;
        }
    }
}
