using Int.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.ReadModel.Teachers
{
    public partial interface ITeacherDao : IRepositoryReadOnly<Teacher> { }
}
