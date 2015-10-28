using ECommon.Components;
using ECommon.Dapper;
using ENode.Eventing;
using ENode.Infrastructure;
using Int.AC.Departments;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.ReadModel.Departments
{
    [Component]
    public class DepartmentViewModelGenerator : BaseEventHandler,
        IEventHandler<DepartmentCreated>,
        IEventHandler<DepartmentUpdated>,
        IEventHandler<DepartmentChangedUsers>
    {
        public void Handle(IHandlingContext context, DepartmentCreated evnt)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                try
                {
                    connection.Insert(
                    new
                    {
                        Id = evnt.AggregateRootId,
                        Name = evnt.Name,
                        ParentId = evnt.ParentId,
                        IsDeleted = 0,
                        CreatedOn = evnt.Timestamp,
                        UpdatedOn = evnt.Timestamp,
                        Version = evnt.Version,
                    }, "Departments");
                }
                catch
                {
                    throw;
                }
            }
        }
        public void Handle(IHandlingContext context, DepartmentUpdated evnt)
        {
            TryUpdateRecord(connection =>
            {
                return connection.Update(
                    new
                    {
                        Name = evnt.Name,
                        Sort = evnt.Sort,
                        ParentId = evnt.ParentId,
                        UpdatedOn = evnt.Timestamp,
                        Version = evnt.Version
                    },
                    new
                    {
                        Id = evnt.AggregateRootId,
                        Version = evnt.Version - 1
                    }, "Departments");
            });
        }
        public void Handle(IHandlingContext context, DepartmentChangedUsers evnt)
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
                            DepartmentId = evnt.AggregateRootId
                        }, "DepartmentUser", transaction
                    );
                    foreach (var userId in evnt.UserIds)
                    {
                        connection.Insert(
                            new
                            {
                                DepartmentId = evnt.AggregateRootId,
                                UserId = userId
                            }, "DepartmentUser", transaction
                        );
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
