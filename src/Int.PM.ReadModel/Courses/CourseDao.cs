using ECommon.Components;
using Int.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.ReadModel.Courses
{
    [Component]
    public partial class CourseDao : RepositoryReadOnly<Course>, ICourseDao
    {
        public CourseDao(EntityFrameUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
