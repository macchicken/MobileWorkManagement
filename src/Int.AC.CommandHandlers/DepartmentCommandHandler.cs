using ENode.Commanding;
using Int.AC.Commands.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Int.AC.Departments;
using ECommon.Components;

namespace Int.AC.CommandHandlers
{
    [Component]
    public class DepartmentCommandHandler : ICommandHandler<CreateDepartment>,
        ICommandHandler<UpdateDepartment>,
        ICommandHandler<SetDepartmentUsers>
    {
        public void Handle(ICommandContext context, CreateDepartment command)
        {
            context.Add(new Department(
                 command.AggregateRootId,
                 command.Name,
                 command.ParentId));
        }
        public void Handle(ICommandContext context, UpdateDepartment command)
        {
            context.Get<Department>(command.AggregateRootId).Update(
                command.Name,
                command.ParentId);
        }
        public void Handle(ICommandContext context, SetDepartmentUsers command)
        {
            context.Get<Department>(command.AggregateRootId).ChangeUsers(
                command.UserIds);
        }
    }
}
