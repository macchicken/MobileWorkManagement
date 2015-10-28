using Int.AC.ReadModel.Roles;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Int.AC.ReadModel.Mapping
{
    class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            HasMany(m => m.Permissions).WithMany().Map(m =>
            {
                m.ToTable("RolePermission");
                m.MapLeftKey("RoleId");
                m.MapRightKey("PermissionId");
            });
        }
    }
}
