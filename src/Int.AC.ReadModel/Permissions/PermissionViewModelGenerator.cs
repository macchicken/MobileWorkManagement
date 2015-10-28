using ECommon.Components;
using ECommon.Dapper;
using ENode.Eventing;
using ENode.Infrastructure;
using Int.AC.Permissions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.ReadModel.Permissions
{
    [Component]
    public class PermissionViewModelGenerator : BaseEventHandler,
        IEventHandler<PermissionCreated>,
        IEventHandler<PermissionUpdated>
    {
        public void Handle(IHandlingContext context, PermissionCreated evnt)
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
                        Code = evnt.Code,
                        Name = evnt.Name,
                        ModuleId = evnt.ModuleId,
                        IsDeleted = 0,
                        CreatedOn = evnt.Timestamp,
                        UpdatedOn = evnt.Timestamp,
                        Version = evnt.Version,
                    }, "Permissions");
                }
                catch
                {
                    throw;
                }
            }
        }
        public void Handle(IHandlingContext context, PermissionUpdated evnt)
        {
            TryUpdateRecord(connection =>
            {
                return connection.Update(
                    new
                    {
                        Code = evnt.Code,
                        Name = evnt.Name,
                        ModuleId = evnt.ModuleId,
                        UpdatedOn = evnt.Timestamp,
                        Version = evnt.Version
                    },
                    new
                    {
                        Id = evnt.AggregateRootId,
                        Version = evnt.Version - 1
                    }, "Permissions");
            });
        }
    }
}
