using ECommon.Components;
using ECommon.Dapper;
using ENode.Eventing;
using ENode.Infrastructure;
using Int.AC.Modules;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.ReadModel.Modules
{
    [Component]
    public class ModuleViewModelGenerator : BaseEventHandler,
        IEventHandler<ModuleCreated>,
        IEventHandler<ModuleUpdated>
    {
        public void Handle(IHandlingContext context, ModuleCreated evnt)
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
                        ServiceId = evnt.ServiceId,
                        Code = evnt.Code,
                        Text = evnt.Text,
                        ParentId = evnt.ParentId,
                        Sort = evnt.Sort,
                        UseAble = 1,
                        IsDeleted = 0,
                        CreatedOn = evnt.Timestamp,
                        UpdatedOn = evnt.Timestamp,
                        Version = evnt.Version,
                    }, "Modules");
                }
                catch
                {
                    throw;
                }
            }
        }
        public void Handle(IHandlingContext context, ModuleUpdated evnt)
        {
            TryUpdateRecord(connection =>
            {
                return connection.Update(
                    new
                    {
                        Code = evnt.Code,
                        Text = evnt.Text,
                        ParentId = evnt.ParentId,
                        Sort = evnt.Sort,
                        UseAble = evnt.UseAble,
                        UpdatedOn = evnt.Timestamp,
                        Version = evnt.Version
                    },
                    new
                    {
                        Id = evnt.AggregateRootId,
                        Version = evnt.Version - 1
                    }, "Modules");
            });
        }
    }
}
