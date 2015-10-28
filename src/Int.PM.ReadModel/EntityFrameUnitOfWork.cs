using ECommon.Components;
using Int.PM.ReadModel.Mapping;
using Int.PM.ReadModel.Projects;
using Int.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.ReadModel
{
    [Component]
    public class EntityFrameUnitOfWork : UnitOfWorkBase
    {
        public EntityFrameUnitOfWork()
            : base("name=PMDBConn")
        {
            this.Configuration.LazyLoadingEnabled=true;
        }

        public DbSet<Project> Projects
        {
            get { return Set<Project>(); }
        }
        public DbSet<ProjectMain> ProjectsMain
        {
            get { return Set<ProjectMain>(); }
        }
        public DbSet<ProjectExtend> ProjectsExtend
        {
            get { return Set<ProjectExtend>(); }
        }
        public DbSet<Consult> Consults
        {
            get { return Set<Consult>(); }
        }
        public DbSet<Proposal> Proposals
        {
            get { return Set<Proposal>(); }
        }
        public DbSet<ControlTable> ControlTable
        {
            get { return Set<ControlTable>(); }
        }
        public DbSet<SubProcess> SubProcess
        {
            get { return Set<SubProcess>(); }
        }
        public DbSet<Assesment> Assesment
        {
            get { return Set<Assesment>(); }
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
            modelBuilder.Configurations.Add(new ProjectMap());
        }
    }
}
