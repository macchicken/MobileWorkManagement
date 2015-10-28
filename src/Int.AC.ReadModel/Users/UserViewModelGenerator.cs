using ECommon.Components;
using ECommon.Dapper;
using ENode.Eventing;
using ENode.Infrastructure;
using Int.AC.Users;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.ReadModel.Users
{
    [Component]
    public class UserViewModelGenerator : BaseEventHandler,
        IEventHandler<UserCreated>,
        IEventHandler<UserUpdated>,
        IEventHandler<PasswordChanged>,
        IEventHandler<UserChangedRoles>
    {
        public void Handle(IHandlingContext context, UserCreated evnt)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    connection.Insert(
                        new
                        {
                            Id = evnt.AggregateRootId,
                            Password = "3F20CDD1F4E260DE570E97C8C4D61411",  //123456
                            Code = evnt.Code,
                            Name = evnt.Name,
                            NameEn = evnt.NameEn,
                            Email = evnt.Email,
                            Phone = evnt.Phone,
                            JobName = evnt.JobName,
                            LeaderId = evnt.LeaderId,
                            UseAble = 1,
                            IsDeleted = 0,
                            CreatedOn = evnt.Timestamp,
                            UpdatedOn = evnt.Timestamp,
                            Version = evnt.Version,
                        }, "Users", transaction
                    );

                    if (evnt.Departments != null)
                    {
                        connection.Delete(
                            new
                            {
                                UserId = evnt.AggregateRootId
                            }, "DepartmentUser", transaction
                        );
                        foreach (var departmentId in evnt.Departments)
                        {
                            connection.Insert(
                                new
                                {
                                    UserId = evnt.AggregateRootId,
                                    DepartmentId = departmentId
                                }, "DepartmentUser", transaction
                            );
                        }
                    }
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void Handle(IHandlingContext context, UserUpdated evnt)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    connection.Update(
                        new
                        {
                            Code = evnt.Code,
                            Name = evnt.Name,
                            NameEn = evnt.NameEn,
                            Email = evnt.Email,
                            Phone = evnt.Phone,
                            JobName = evnt.JobName,
                            LeaderId = evnt.LeaderId,
                            UseAble = evnt.UseAble,
                            UpdatedOn = evnt.Timestamp,
                            Version = evnt.Version
                        },
                        new
                        {
                            Id = evnt.AggregateRootId,
                            Version = evnt.Version - 1
                        }, "Users", transaction
                    );
                    if (evnt.Departments != null)
                    {
                        connection.Delete(
                            new
                            {
                                UserId = evnt.AggregateRootId
                            }, "DepartmentUser", transaction
                        );
                        foreach (var departmentId in evnt.Departments)
                        {
                            connection.Insert(
                                new
                                {
                                    UserId = evnt.AggregateRootId,
                                    DepartmentId = departmentId
                                }, "DepartmentUser", transaction
                            );
                        }
                    }
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void Handle(IHandlingContext context, PasswordChanged evnt)
        {
 	        TryUpdateRecord(connection =>
            {
                return connection.Update(
                    new
                    {
                        Password = evnt.Password,
                        UpdatedOn = evnt.Timestamp,
                        Version = evnt.Version
                    },
                    new
                    {
                        Id = evnt.AggregateRootId,
                        Version = evnt.Version - 1
                    }, "Users");
            });
        }
        public void Handle(IHandlingContext context, UserChangedRoles evnt)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    connection.Delete(
                    new
                    {
                        UserId = evnt.AggregateRootId
                    }, "UserRole", transaction);
                    foreach (var roleId in evnt.RoleIds)
                    {
                        connection.Insert(
                        new
                        {
                            UserId = evnt.AggregateRootId,
                            RoleId = roleId
                        }, "UserRole", transaction);
                    }
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
