using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Shop.Catalog.Api.Controllers;
using Shop.Catalog.Api.Models;
using Shop.Catalog.Api.Repositories;
using Xunit;

namespace Shop.Catalog.Api.Tests.Unit
{
    public class ProductsControllerTests
    {
        [Fact]
        public void ProductsController_Throws_ArgumentNullException_On_Null_ProductRepository()
        {
            Assert.Throws<ArgumentNullException>(() => new ProductsController(null));
        }

        [Fact]
        public async Task ProductsController_Get_Returns_Product_List()
        {
            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository.Setup(x => x.GetProducts(It.IsAny<ProductOptions>()))
                .Returns(Task.FromResult(GetProducts()));
            var productsController = new ProductsController(mockProductRepository.Object);
            var products = await productsController.GetAsync();

            Assert.Equal(2,products.Count());
        }

        [Fact]
        public async Task ProductsController_Get_By_UPC_Returns_Product()
        {
            var upc = "12345";
            var mockProductRepository = new Mock<IProductRepository>();
            var mockProduct = GetProducts().Where(x => x.Upc == upc)?.FirstOrDefault();
            mockProductRepository.Setup(x => x.GetProduct(It.Is<string>(y=>y.Equals(upc))))
                .Returns(Task.FromResult(mockProduct));

            var productsController = new ProductsController(mockProductRepository.Object);
            var product = await productsController.GetAsync(upc);

            Assert.NotNull(mockProduct);
            Assert.NotNull(product);
            Assert.Equal(mockProduct.SalePrice, product.SalePrice);
            Assert.Equal(mockProduct.ListPrice, product.ListPrice);
            Assert.Equal(mockProduct.Upc, product.Upc);
            Assert.Equal(mockProduct.Category, product.Category);
            Assert.Equal(mockProduct.Name, product.Name);
        }

        private IEnumerable<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Category = "Movies",
                    Name = "Mission Impossible",
                    Upc = "12345",
                    ListPrice = 20.99m,
                    SalePrice = 16.99m
                },
                new Product
                {
                    Category = "Movies",
                    Name = "Mission Impossible 2",
                    Upc = "34567",
                    ListPrice = 22.99m,
                    SalePrice = 18.99m
                }
            };
        }
    }
}
