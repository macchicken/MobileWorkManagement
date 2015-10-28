using Int.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.ReadModel.Menus
{
    public partial interface IMenuDao : IRepositoryReadOnly<Menu>
    {
        List<MenuInfo> GetUserMenus(string userId, MenuType type);
    }
}
