using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace KristinsKitchen.Repositories
{
    public abstract class BaseRespository
    {
        private readonly string _connectionString;
        public BaseRespository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        protected SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }
    }
}
