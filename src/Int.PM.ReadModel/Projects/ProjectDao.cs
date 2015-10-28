using ECommon.Components;
using Int.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.ReadModel.Projects
{
    //项目信息查询
    [Component]
    public partial class ProjectDao : RepositoryReadOnly<Project>, IProjectDao
    {
        public ProjectDao(EntityFrameUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
