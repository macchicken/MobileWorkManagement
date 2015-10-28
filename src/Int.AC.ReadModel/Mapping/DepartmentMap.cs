using Int.AC.ReadModel.Departments;
using System.Data.Entity.ModelConfiguration;

namespace Int.AC.ReadModel.Mapping
{
    class DepartmentMap : EntityTypeConfiguration<Department>
    {
        public DepartmentMap()
        {
            this.Property(m => m.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            HasMany(m => m.Users).WithMany(m => m.Departments).Map(m =>
            {
                m.ToTable("DepartmentUser");
                m.MapLeftKey("DepartmentId");
                m.MapRightKey("UserId");
            });
        }
    }
}
