namespace Shop.Catalog.Domain.Entities
{
    public class Product
    {
        public string Description { get; set; }
        public string ProductName { get; set; }
        public string ProductUpc { get; set; }
        public decimal ListPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Discount => ListPrice - SalePrice;
    }
}
