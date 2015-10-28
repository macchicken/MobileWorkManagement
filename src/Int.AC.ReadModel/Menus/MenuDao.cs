using ECommon.Components;
using Int.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.ReadModel.Menus
{
    [Component]
    public partial class MenuDao : RepositoryReadOnly<Menu>, IMenuDao
    {
        public MenuDao(EntityFrameUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public List<MenuInfo> GetUserMenus(string userId, MenuType type)
        {
            var currentUnitOfWork = this.UnitOfWork as EntityFrameUnitOfWork;

            string sql = string.Empty;
            if (type != MenuType.All)
            {
                sql = "AND (m.[MenuType]=" + (int)MenuType.All + @" OR m.[MenuType]=" + (int)type + @")";
            }

            var list = currentUnitOfWork.ExecuteQuery<MenuInfo>(
                        @"WITH tree([Id],[Text],[MenuType],[NavigateUrl],[MobileUrl],[ParentId],[Sort],[PermissionId],[ServiceUrl])AS(
                            SELECT m.[Id],m.[Text],m.[MenuType],m.[NavigateUrl],m.[MobileUrl],m.[ParentId],m.[Sort],m.[PermissionId],s.[Url]
	                        FROM menus as m
	                        INNER JOIN Permissions as p on p.Id = m.PermissionId
                            INNER JOIN Modules as d on d.Id = p.ModuleId
                            INNER JOIN Services as s on s.Id = d.ServiceId
	                        INNER JOIN RolePermission as rp on rp.PermissionId = p.Id
	                        INNER JOIN Roles as r on r.Id = rp.RoleId 
	                        INNER JOIN UserRole as ur on ur.RoleId = r.Id
	                        INNER JOIN Users as u on u.Id = ur.UserId
	                        WHERE m.IsDeleted = 0 AND r.IsDeleted = 0 AND u.IsDeleted = 0
	                        AND m.UseAble = 1 AND r.UseAble = 1 AND u.UseAble = 1 AND u.Id = '" + userId + @"' " + sql + @"
							UNION ALL

							SELECT m.[Id],m.[Text],m.[MenuType],m.[NavigateUrl],m.[MobileUrl],m.[ParentId],m.[Sort],m.[PermissionId], null as [ServiceUrl]
                            FROM menus as m
							WHERE m.PermissionId is null " + sql + @"

                            UNION ALL

                            SELECT m.[Id],m.[Text],m.[MenuType],m.[NavigateUrl],m.[MobileUrl],m.[ParentId],m.[Sort],m.[PermissionId], null as [ServiceUrl]
                            FROM menus as m
                            INNER JOIN tree ON tree.parentId=m.id
                            WHERE m.IsDeleted = 0 AND m.UseAble = 1
                        )
                        SELECT distinct * FROM tree ").ToList();
            return list;
        }
    }
}
