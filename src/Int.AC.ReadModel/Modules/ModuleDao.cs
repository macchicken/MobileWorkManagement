using ECommon.Components;
using Int.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.ReadModel.Modules
{
    [Component]
    public partial class ModuleDao : RepositoryReadOnly<Module>, IModuleDao
    {
        public ModuleDao(EntityFrameUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public List<Module> GetUserModules(string userId)
        {
            var currentUnitOfWork = this.UnitOfWork as EntityFrameUnitOfWork;
            var list = currentUnitOfWork.ExecuteQuery<Module>(
                        @"WITH tree([Id],[ServiceId],[Code],[Text],[ParentId],[Sort],[UseAble],[IsDeleted],[CreatedOn],[UpdatedOn],[Version],[Sequence],[Timestamp])AS(
                            SELECT m.[Id],m.[ServiceId],m.[Code],m.[Text],m.[ParentId],m.[Sort],m.[UseAble],m.[IsDeleted],m.[CreatedOn],
                                   m.[UpdatedOn],m.[Version],m.[Sequence],m.[Timestamp]
	                        FROM modules as m
	                        INNER JOIN Permissions as p on p.ModuleId = m.Id
	                        INNER JOIN RolePermission as rp on rp.PermissionId = p.Id
	                        INNER JOIN Roles as r on r.Id = rp.RoleId 
	                        INNER JOIN UserRole as ur on ur.RoleId = r.Id
	                        INNER JOIN Users as u on u.Id = ur.UserId
	                        WHERE m.IsDeleted = 0 AND p.IsDeleted = 0 AND r.IsDeleted = 0 AND u.IsDeleted = 0
	                        AND m.UseAble = 1 AND r.UseAble = 1 AND u.UseAble = 1 AND u.Id = '" + userId + @"'

                            UNION ALL

                            SELECT m.[Id],m.[ServiceId],m.[Code],m.[Text],m.[ParentId],m.[Sort],m.[UseAble],m.[IsDeleted],m.[CreatedOn],
                                   m.[UpdatedOn],m.[Version],m.[Sequence],m.[Timestamp]
                            FROM modules as m
                            INNER JOIN tree ON tree.parentId=m.id
                            WHERE m.IsDeleted = 0 AND m.UseAble = 1
                        )
                        SELECT distinct * FROM tree ").ToList();
            return list;
        }

        public bool SetDataPermissions(int moduleId, int[] permissionIds)
        {
            var currentUnitOfWork = this.UnitOfWork as EntityFrameUnitOfWork;
            currentUnitOfWork.ExecuteCommand("delete from ModuleDataPermission where ModuleId =" + moduleId);
            foreach (var item in permissionIds)
            {
                currentUnitOfWork.ExecuteCommand("insert into ModuleDataPermission(ModuleId, DataPermissionId) values(" + moduleId + ", " + item + ")");
            }
            return true;
        }
    }
}
