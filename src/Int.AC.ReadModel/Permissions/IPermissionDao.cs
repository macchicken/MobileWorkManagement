using Int.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.ReadModel.Permissions
{
    public partial interface IPermissionDao : IRepositoryReadOnly<Permission> {
        List<Permission> GetUserPermissions(string userId);

        bool CheckPermisstion(string userId, string permissionCode);
    }
}
