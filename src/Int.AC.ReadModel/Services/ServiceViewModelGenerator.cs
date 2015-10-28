using ECommon.Components;
using ECommon.Dapper;
using ENode.Eventing;
using ENode.Infrastructure;
using Int.AC.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.ReadModel.Services
{
    [Component]
    public class ServiceViewModelGenerator : BaseEventHandler,
        IEventHandler<ServiceCreated>,
        IEventHandler<ServiceUpdated>
    {
        public void Handle(IHandlingContext context, ServiceCreated evnt)
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
                        Url = evnt.Url,
                        IsDeleted = 0,
                        CreatedOn = evnt.Timestamp,
                        UpdatedOn = evnt.Timestamp,
                        Version = evnt.Version,
                    }, "Services");
                }
                catch
                {
                    throw;
                }
            }
        }
        public void Handle(IHandlingContext context, ServiceUpdated evnt)
        {
            TryUpdateRecord(connection =>
            {
                return connection.Update(
                    new
                    {
                        Name = evnt.Name,
                        Sort = evnt.Sort,
                        Url = evnt.Url,
                        UpdatedOn = evnt.Timestamp,
                        Version = evnt.Version
                    },
                    new
                    {
                        Id = evnt.AggregateRootId,
                        Version = evnt.Version - 1
                    }, "Services");
            });
        }
    }
}
