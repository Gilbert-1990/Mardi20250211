using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace Mardi20250211.C_DAL.Helper
{
    public class SqlServicesConnectionFactory : ISqlServicesConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public SqlServicesConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<SqlConnection> GetConnectionAsync()
        {
            try
            {
                //var connectionString = _configuration.GetConnectionString("LaboConnectionString");
                //var connection = new SqlConnection(connectionString);
                //await connection.OpenAsync();
                //return connection;

                // Création de l'instance de ConnectionStringManager
                //var configConnectionString = _configuration.GetConnectionString("LaboConnectionString");

                string connectionString = ConnectioStringManager.GetCustomConnectionString(_configuration);

                var connection = new SqlConnection(connectionString);
                await connection.OpenAsync();
                return connection;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}