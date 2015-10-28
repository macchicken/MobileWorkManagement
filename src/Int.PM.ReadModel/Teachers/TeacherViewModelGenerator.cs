using ECommon.Components;
using ECommon.Dapper;
using ENode.Eventing;
using ENode.Infrastructure;
using Int.PM.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.ReadModel.Teachers
{
    [Component]
    public class TeacherViewModelGenerator : BaseEventHandler,
        IEventHandler<TeacherCreated>,
        IEventHandler<TeacherUpdated>,
        IEventHandler<TeacherChangedDetail>
    {
        public void Handle(IHandlingContext context, TeacherCreated evnt)
        {
            //using (var connection = GetConnection())
            //{
            //    connection.Open();
            //    try
            //    {
            //        connection.Insert(
            //        new
            //        {
            //            Id = evnt.AggregateRootId,
            //            Name = evnt.Name,
            //            Sex = evnt.Sex,
            //            Age = evnt.Age,
            //            Source = evnt.Source,
            //            IsInOffice = evnt.IsInOffice,
            //            LeaveOfficeTime = evnt.LeaveOfficeTime,
            //            Seniority = evnt.Seniority,
            //            WorkingTimePlan = evnt.WorkingTimePlan,
            //            Province = evnt.Province,
            //            City = evnt.City,
            //            OfficePhone = evnt.OfficePhone,
            //            PersonalCall = evnt.PersonalCall,
            //            Email = evnt.Email,
            //            QQMsn = evnt.QQMsn,
            //            LinkMan = evnt.LinkMan,
            //            LinkPhone = evnt.LinkPhone,
            //            LinkEmail = evnt.LinkEmail,
            //            SigningType = evnt.SigningType,
            //            WorkExperiences = evnt.WorkExperiences,
            //            TeachExperiences = evnt.TeachExperiences,
            //            Tags = evnt.Tags,
            //            EduExperience = evnt.EduExperience,
            //            Territories = evnt.Territories,
            //            Specialty = evnt.Specialty,
            //            Industries = evnt.Industries,
            //            PromoteMan = evnt.PromoteMan,
            //            PromotePhone = evnt.PromotePhone,
            //            Price = evnt.Price,
            //            Remark = evnt.Remark,
            //            TeamType = evnt.TeamType,
            //            IsDeleted = 0,
            //            CreatedOn = evnt.Timestamp,
            //            UpdatedOn = evnt.Timestamp,
            //            Version = evnt.Version,
            //        }, "Teachers");
            //    }
            //    catch
            //    {
            //        throw;
            //    }
            //}
        }
        public void Handle(IHandlingContext context, TeacherUpdated evnt)
        {
            //TryUpdateRecord(connection =>
            //{
            //    return connection.Update(
            //        new
            //        {
            //            Name = evnt.Name,
            //            Sex = evnt.Sex,
            //            Age = evnt.Age,
            //            Source = evnt.Source,
            //            IsInOffice = evnt.IsInOffice,
            //            LeaveOfficeTime = evnt.LeaveOfficeTime,
            //            Seniority = evnt.Seniority,
            //            WorkingTimePlan = evnt.WorkingTimePlan,
            //            Province = evnt.Province,
            //            City = evnt.City,
            //            OfficePhone = evnt.OfficePhone,
            //            PersonalCall = evnt.PersonalCall,
            //            Email = evnt.Email,
            //            QQMsn = evnt.QQMsn,
            //            LinkMan = evnt.LinkMan,
            //            LinkPhone = evnt.LinkPhone,
            //            LinkEmail = evnt.LinkEmail,
            //            SigningType = evnt.SigningType,
            //            WorkExperiences = evnt.WorkExperiences,
            //            TeachExperiences = evnt.TeachExperiences,
            //            Tags = evnt.Tags,
            //            EduExperience = evnt.EduExperience,
            //            Territories = evnt.Territories,
            //            Specialty = evnt.Specialty,
            //            Industries = evnt.Industries,
            //            PromoteMan = evnt.PromoteMan,
            //            PromotePhone = evnt.PromotePhone,
            //            Price = evnt.Price,
            //            Remark = evnt.Remark,
            //            TeamType = evnt.TeamType,
            //            UpdatedOn = evnt.Timestamp,
            //            Version = evnt.Version
            //        },
            //        new
            //        {
            //            Id = evnt.AggregateRootId,
            //            Version = evnt.Version - 1
            //        }, "Teachers");
            //});
        }
        public void Handle(IHandlingContext context, TeacherChangedDetail evnt)
        {
            //TryUpdateRecord(connection =>
            //{
            //    return connection.Update(
            //        new
            //        {
            //            Name = evnt.Name,
            //            Sex = evnt.Sex,
            //            Age = evnt.Age,
            //            Source = evnt.Source,
            //            IsInOffice = evnt.IsInOffice,
            //            LeaveOfficeTime = evnt.LeaveOfficeTime,
            //            Seniority = evnt.Seniority,
            //            WorkingTimePlan = evnt.WorkingTimePlan,
            //            Province = evnt.Province,
            //            City = evnt.City,
            //            OfficePhone = evnt.OfficePhone,
            //            PersonalCall = evnt.PersonalCall,
            //            Email = evnt.Email,
            //            QQMsn = evnt.QQMsn,
            //            LinkMan = evnt.LinkMan,
            //            LinkPhone = evnt.LinkPhone,
            //            LinkEmail = evnt.LinkEmail,
            //            SigningType = evnt.SigningType,
            //            WorkExperiences = evnt.WorkExperiences,
            //            TeachExperiences = evnt.TeachExperiences,
            //            Tags = evnt.Tags,
            //            EduExperience = evnt.EduExperience,
            //            Territories = evnt.Territories,
            //            Specialty = evnt.Specialty,
            //            Industries = evnt.Industries,
            //            PromoteMan = evnt.PromoteMan,
            //            PromotePhone = evnt.PromotePhone,
            //            Price = evnt.Price,
            //            Remark = evnt.Remark,
            //            TeamType = evnt.TeamType,
            //            UpdatedOn = evnt.Timestamp,
            //            Version = evnt.Version
            //        },
            //        new
            //        {
            //            Id = evnt.AggregateRootId,
            //            Version = evnt.Version - 1
            //        }, "Teachers");
            //});
        }
    }
}
