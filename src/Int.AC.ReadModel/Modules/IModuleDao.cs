using Int.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.ReadModel.Modules
{
    public partial interface IModuleDao : IRepositoryReadOnly<Module> {
        List<Module> GetUserModules(string userId);

        bool SetDataPermissions(int moduleId, int[] permissionIds);
    }
}
