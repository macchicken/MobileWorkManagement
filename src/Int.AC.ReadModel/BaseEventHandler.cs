using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.ReadModel
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
            return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ACDBConn"].ConnectionString);
        }
    }

    public class NoRowsUpdateException : Exception
    {
    }
}