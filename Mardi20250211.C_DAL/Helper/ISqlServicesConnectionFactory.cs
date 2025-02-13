using Microsoft.Data.SqlClient;

namespace Mardi20250211.C_DAL.Helper
{
    public interface ISqlServicesConnectionFactory
    {
        Task<SqlConnection> GetConnectionAsync();
    }
}