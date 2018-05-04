using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Catalog.Api.Repositories
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
