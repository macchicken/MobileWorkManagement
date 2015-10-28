using ENode.Commanding;
using Int.PM.Commands.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Int.PM.Dictionaries;
using ECommon.Components;
using Int.PM.Commands.Courses;
using Int.PM.Courses;

namespace Int.PM.CommandHandlers
{
    [Component]
    public class CourseCommandHandler : ICommandHandler<CreateCourse>,
        ICommandHandler<UpdateCourse>
    {
        public void Handle(ICommandContext context, CreateCourse command)
        {
            context.Add(new Course(
                command.AggregateRootId,
                command.Name,
                command.Describe,
                command.Remark,
                command.Products,
                command.CourseCategories,
                command.JobCategories,
                command.Tags
            ));
        }
        public void Handle(ICommandContext context, UpdateCourse command)
        {
            context.Get<Course>(command.AggregateRootId).Update(
                 command.Name,
                command.Describe,
                command.Remark,
                command.Products,
                command.CourseCategories,
                command.JobCategories,
                command.Tags
            );
        }
    }
}
