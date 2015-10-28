using ENode.Commanding;
using Int.PM.Commands.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Int.PM.Dictionaries;
using ECommon.Components;
using Int.PM.Commands.Teachers;
using Int.PM.Teachers;

namespace Int.PM.CommandHandlers
{
    [Component]
    public class TeacherCommandHandler : ICommandHandler<CreateTeacher>,
        ICommandHandler<UpdateTeacher>
    {
        public void Handle(ICommandContext context, CreateTeacher command)
        {
            context.Add(new Teacher(
                command.AggregateRootId,
                command.Name,
                command.Sex,
                command.Source,
                command.Seniority,
                command.OfficePhone,
                command.PersonalCall,
                command.Email,
                command.Specialty,
                command.PromoteMan,
                command.PromotePhone,
                command.TeamType,
                command.Tags
            ));
        }
        public void Handle(ICommandContext context, UpdateTeacher command)
        {
            context.Get<Teacher>(command.AggregateRootId).Update(
                command.Name,
                command.Sex,
                command.Source,
                command.Seniority,
                command.OfficePhone,
                command.PersonalCall,
                command.Email,
                command.Specialty,
                command.PromoteMan,
                command.PromotePhone,
                command.TeamType,
                command.Tags
            );
        }
        public void Handle(ICommandContext context, ChangeDetailTeacher command)
        {
            context.Get<Teacher>(command.AggregateRootId).ChangeDetail(
                command.Age,
                command.IsInOffice,
                command.LeaveOfficeTime,
                command.WorkingTimePlan,
                command.Province,
                command.City,
                command.QQMsn,
                command.LinkMan,
                command.LinkPhone,
                command.LinkEmail,
                command.SigningType,
                command.WorkExperiences,
                command.TeachExperiences,
                command.EduExperience,
                command.Price,
                command.Remark,
                command.Territories,
                command.Industries
            );
        }
    }
}
