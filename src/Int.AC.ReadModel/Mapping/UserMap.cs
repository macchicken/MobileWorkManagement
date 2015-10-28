using Int.AC.ReadModel.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Int.AC.ReadModel.Mapping
{
    class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasMany(m => m.Roles).WithMany(m => m.Users).Map(m =>
            {
                m.ToTable("UserRole");
                m.MapLeftKey("UserId");
                m.MapRightKey("RoleId");
            });
        }
    }
}
