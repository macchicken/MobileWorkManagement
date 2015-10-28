using Int.PM.ReadModel.Projects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Int.PM.ReadModel.Mapping
{
    //项目数据库对象的关系定义
    class ProjectMap : EntityTypeConfiguration<Project>
    {
        public ProjectMap()
        {
            this.HasOptional(m => m.ProjectMain).WithRequired();
            this.HasOptional(m => m.ProjectExtend).WithRequired();
            this.HasOptional(m => m.Consult).WithRequired();
        }
    }
}
