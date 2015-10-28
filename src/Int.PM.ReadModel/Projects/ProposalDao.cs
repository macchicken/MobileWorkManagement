using ECommon.Components;
using Int.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.ReadModel.Projects
{
    //提案信息查询
    [Component]
    public partial class ProposalDao : RepositoryReadOnly<Proposal>, IProposalDao
    {
        public ProposalDao(EntityFrameUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
