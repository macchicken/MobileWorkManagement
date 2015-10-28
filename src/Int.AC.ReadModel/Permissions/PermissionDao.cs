using ECommon.Components;
using Int.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.ReadModel.Permissions
{
    [Component]
    public partial class PermissionDao : RepositoryReadOnly<Permission>, IPermissionDao
    {
        public PermissionDao(EntityFrameUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public List<Permission> GetUserPermissions(string userId)
        {
            var currentUnitOfWork = this.UnitOfWork as EntityFrameUnitOfWork;
            var list = currentUnitOfWork.ExecuteQuery<Permission>(
                          @"SELECT distinct p.*
                                FROM Permissions as p 
                                INNER JOIN Modules as m on m.Id = p.ModuleId
                                INNER JOIN RolePermission as rp on rp.PermissionId = p.Id
                                INNER JOIN Roles as r on r.Id = rp.RoleId 
                                INNER JOIN UserRole as ur on ur.RoleId = r.Id
                                INNER JOIN Users as u on u.Id = ur.UserId
                                WHERE  p.IsDeleted = 0 AND r.IsDeleted = 0 AND u.IsDeleted = 0
                                 AND r.UseAble = 1 AND u.UseAble = 1 AND u.Id='" + userId + "'").ToList();
            return list;
        }

        public bool CheckPermisstion(string userId, string permissionCode)
        {
            var currentUnitOfWork = this.UnitOfWork as EntityFrameUnitOfWork;
            var count = currentUnitOfWork.ExecuteQuery<int>(
                          @"SELECT count(*)
                            FROM Permissions as p 
                            INNER JOIN RolePermission as rp on rp.PermissionId = p.Id
                            INNER JOIN Roles as r on r.Id = rp.RoleId 
                            INNER JOIN UserRole as ur on ur.RoleId = r.Id
                            INNER JOIN Users as u on u.Id = ur.UserId
                            WHERE  p.IsDeleted = 0 AND r.IsDeleted = 0 AND u.IsDeleted = 0 AND p.Code = '" + permissionCode + @"'
                             AND r.UseAble = 1 AND u.UseAble = 1 AND u.Id='" + userId + "'").ToList();
            return count[0] > 0;
        }
    }
}
