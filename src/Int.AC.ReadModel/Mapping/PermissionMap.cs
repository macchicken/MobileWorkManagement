using Int.AC.ReadModel.Permissions;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Int.AC.ReadModel.Mapping
{
    class PermissionMap : EntityTypeConfiguration<Permission>
    {
        public PermissionMap()
        {
            HasRequired(m => m.Module).WithMany().HasForeignKey(m => m.ModuleId);
        }
    }
}
