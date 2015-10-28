using ECommon.Components;
using Int.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.ReadModel.Teachers
{
    [Component]
    public partial class TeacherDao : RepositoryReadOnly<Teacher>, ITeacherDao
    {
        public TeacherDao(EntityFrameUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
