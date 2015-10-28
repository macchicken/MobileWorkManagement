using ECommon.Components;
using Int.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.ReadModel.Departments
{
    [Component]
    public partial class DepartmentDao : RepositoryReadOnly<Department>, IDepartmentDao
    {
        public DepartmentDao(EntityFrameUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
