using ECommon.Utilities;
using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.Commands.Projects
{
    [Serializable]
    public class CreateProposal : AggregateCommand<string>
    {
        public int State { get; private set; }
        public string ProposalOwner { get; private set; }
        public DateTime ProposalStart { get; private set; }

        public CreateProposal(string id,int state, string proposalOwner, DateTime proposalStart):base(id)
        {
            State = state;
            ProposalOwner = proposalOwner;
            ProposalStart = proposalStart;
        }
    }
}
