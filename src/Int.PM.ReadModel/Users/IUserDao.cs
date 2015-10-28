using Int.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.ReadModel.Users
{
    public partial interface IUserDao : IRepositoryReadOnly<User> { }
}
