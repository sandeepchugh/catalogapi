using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Catalog.Domain.Entities;
using Shop.Catalog.Domain.Repositories;

namespace Shop.Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }
        
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await _productRepository.GetProducts(new ProductOptions());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Product> GetAsync(string upc)
        {
            return await _productRepository.GetProduct(upc);
        }
    }
}
