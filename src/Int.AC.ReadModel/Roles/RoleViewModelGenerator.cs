using ECommon.Components;
using ECommon.Dapper;
using ENode.Eventing;
using ENode.Infrastructure;
using Int.AC.Roles;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.ReadModel.Roles
{
    [Component]
    public class RoleViewModelGenerator : BaseEventHandler,
        IEventHandler<RoleCreated>,
        IEventHandler<RoleUpdated>,
        IEventHandler<RoleChangedPermissions>
    {
        public void Handle(IHandlingContext context, RoleCreated evnt)
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
                        Sort = evnt.Sort,
                        UseAble = 1,
                        IsDeleted = 0,
                        CreatedOn = evnt.Timestamp,
                        UpdatedOn = evnt.Timestamp,
                        Version = evnt.Version,
                    }, "Roles");
                }
                catch
                {
                    throw;
                }
            }
        }
        public void Handle(IHandlingContext context, RoleUpdated evnt)
        {
            TryUpdateRecord(connection =>
            {
                return connection.Update(
                    new
                    {
                        Name = evnt.Name,
                        Sort = evnt.Sort,
                        UseAble = evnt.UseAble,
                        UpdatedOn = evnt.Timestamp,
                        Version = evnt.Version
                    },
                    new
                    {
                        Id = evnt.AggregateRootId,
                        Version = evnt.Version - 1
                    }, "Roles");
            });
        }

        public void Handle(IHandlingContext context, RoleChangedPermissions evnt)
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
                        RoleId = evnt.AggregateRootId
                    }, "RolePermission", transaction);
                    foreach (var permissionId in evnt.PermissionIds)
                    {
                        connection.Insert(
                        new
                        {
                            RoleId = evnt.AggregateRootId,
                            PermissionId = permissionId
                        }, "RolePermission", transaction);
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
