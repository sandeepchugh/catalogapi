using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.Catalog.Domain.Entities;

namespace Shop.Catalog.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts(ProductOptions options);
        Task<Product> GetProduct(string upc);
    }
}
