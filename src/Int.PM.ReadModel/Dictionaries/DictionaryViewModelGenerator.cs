using ECommon.Components;
using ECommon.Dapper;
using ENode.Eventing;
using ENode.Infrastructure;
using Int.PM.Dictionaries;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.ReadModel.Dictionaries
{
    [Component]
    public class DictionaryViewModelGenerator : BaseEventHandler,
        IEventHandler<DictionaryCreated>,
        IEventHandler<DictionaryUpdated>
    {
        public void Handle(IHandlingContext context, DictionaryCreated evnt)
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
                    }, GetTableName(evnt.Type));
                }
                catch
                {
                    throw;
                }
            }
        }
        public void Handle(IHandlingContext context, DictionaryUpdated evnt)
        {
            TryUpdateRecord(connection =>
            {
                return connection.Update(
                    new
                    {
                        Name = evnt.Name,
                        ParentId = evnt.ParentId,
                        UpdatedOn = evnt.Timestamp,
                        Version = evnt.Version
                    },
                    new
                    {
                        Id = evnt.AggregateRootId,
                        Version = evnt.Version - 1
                    }, GetTableName(evnt.Type));
            });
        }

        private string GetTableName(int type)
        {
            switch ((DictionaryType)type)
            { 
                case DictionaryType.ConsultantCategory:
                    return "ConsultantCategories";
                case DictionaryType.CourseCategory:
                    return "CourseCategories";
                case DictionaryType.Industry:
                    return "Industries";
                case DictionaryType.JobCategory:
                    return "JobCategories";
                case DictionaryType.Territory:
                    return "Territories";
                default:
                    return "";
            }
        }
    }
}
