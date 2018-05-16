using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Shop.Catalog.Domain.Repositories;

namespace Shop.Catalog.Repositories.MySql.Repositories
{
    public class MySqlConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public MySqlConnectionFactory(IConfiguration configuration,string connectionStringName)
        {
            _connectionString = configuration.GetConnectionString(connectionStringName);
        }
        public IDbConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}
