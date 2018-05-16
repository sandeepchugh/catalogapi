using System.Data;

namespace Shop.Catalog.Domain.Repositories
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
