using Int.AC.ReadModel.Menus;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Int.AC.ReadModel.Mapping
{
    class MenuMap : EntityTypeConfiguration<Menu>
    {
        public MenuMap()
        {
            this.HasOptional(m => m.Permission).WithMany().HasForeignKey(m => m.PermissionId);
        }
    }
}
