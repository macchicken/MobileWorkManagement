using ECommon.Components;
using Int.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.ReadModel.Projects
{
    [Component]
    public partial class AssessmentDao : RepositoryReadOnly<Assesment>, IAssessmentDao
    {
        public AssessmentDao(EntityFrameUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
