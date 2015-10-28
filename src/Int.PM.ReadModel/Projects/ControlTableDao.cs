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
    public partial class ControlTableDao : RepositoryReadOnly<ControlTable>,IControlTableDao
    {
        public ControlTableDao(EntityFrameUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
