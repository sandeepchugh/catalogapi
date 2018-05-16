namespace Shop.Catalog.Domain.Entities
{
    public class Product
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public string Upc { get; set; }
        public decimal ListPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Discount => ListPrice - SalePrice;
    }
}
