using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.ReadModel
{
    public abstract class BaseEventHandler
    {
        protected void TryUpdateRecord(Func<IDbConnection, int> action)
        {
            using (var connection = GetConnection())
            {
                var result = action(connection);
                if (result != 1)
                {
                    throw new NoRowsUpdateException();
                }
            }
        }
        protected IDbConnection GetConnection()
        {
            return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PMDBConn"].ConnectionString);
        }
    }

    public class NoRowsUpdateException : Exception
    {
    }
}


//using (var connection = new SqlConnection(dbConfig))
//{
//    connection.Open();
//    var transaction = connection.BeginTransaction();
//    try
//    {
//        connection.Insert(
//        new
//        {
//            Id = evnt.AggregateRootId,
//            PaymentSourceId = evnt.SortId,
//            StateValue = (int)PaymentState.Initiated,
//            Description = evnt.Description,
//            Amount = evnt.TotalAmount
//        }, "ThirdPartyProcessorPayments", transaction);
//        transaction.Commit();
//    }
//    catch
//    {
//        transaction.Rollback();
//        throw;
//    }
//}