using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Shop.Catalog.Domain.Entities;
using Shop.Catalog.Domain.Repositories;

namespace Shop.Catalog.Repositories.MySql.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ProductRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentException(nameof(connectionFactory));
        }
        public async Task<IEnumerable<Product>> GetProducts(ProductOptions options)
        {
            IEnumerable<Product> products;
            var query = "SELECT * FROM Products";
            using (IDbConnection connection = _connectionFactory.CreateConnection())
            {
                products = await connection.QueryAsync<Product>(query);
            }

            return products;
        }

        public async Task<Product> GetProduct(string upc)
        {
            Product product;
            var query = "SELECT * FROM Products WHERE Upc=@upc";
            using (IDbConnection connection = _connectionFactory.CreateConnection())
            {
                product = await connection.QuerySingle(query, upc);
            }

            return product;
        }
    }
}
