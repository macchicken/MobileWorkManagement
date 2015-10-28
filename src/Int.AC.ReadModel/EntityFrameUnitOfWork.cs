using ECommon.Components;
using Int.AC.ReadModel.Departments;
using Int.AC.ReadModel.Mapping;
using Int.AC.ReadModel.Menus;
using Int.AC.ReadModel.Permissions;
using Int.AC.ReadModel.Roles;
using Int.AC.ReadModel.Services;
using Int.AC.ReadModel.Users;
using Int.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.ReadModel
{
    [Component]
    public class EntityFrameUnitOfWork : UnitOfWorkBase
    {
        public EntityFrameUnitOfWork()
            : base("name=ACDBConn")
        {
        }


        public DbSet<User> Users
        {
            get { return Set<User>(); }
        }

        public DbSet<Role> Roles
        {
            get { return Set<Role>(); }
        }

        public DbSet<Menu> Menus
        {
            get { return Set<Menu>(); }
        }

        public DbSet<Permission> Permissions
        {
            get { return Set<Permission>(); }
        }
        public DbSet<DepartmentStaff> DepartmentStaffs
        {
            get { return Set<DepartmentStaff>(); }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //移除一对多的级联删除约定，想要级联删除可以在 EntityTypeConfiguration<TEntity>的实现类中进行控制
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            SetModelMap(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        //分成多个方法是为了解决CA1506过度类耦合警告
        private void SetModelMap(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new DepartmentMap());
            modelBuilder.Configurations.Add(new PermissionMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new MenuMap());
        }
    }
}
