using System.Configuration;
using System.Data.SqlClient;

namespace Pe.ByS.ERP.Infrastructure.Persistence
{
    public class ConnectionFactory
    {
        public static SqlConnection Create(string connectionStringKey)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionStringKey].ConnectionString);
            connection.Open();
            return connection;
        }

        public static SqlConnection DefaultConnection()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[PersistenceConfigurator.ConnectionStringKey].ConnectionString);
            connection.Open();
            return connection;
        }
    }
}