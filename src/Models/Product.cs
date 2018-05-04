using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Catalog.Api.Models
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
