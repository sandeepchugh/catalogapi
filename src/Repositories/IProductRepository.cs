using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Catalog.Api.Models;

namespace Shop.Catalog.Api.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts(ProductOptions options);
        Task<Product> GetProduct(string upc);
    }
}
