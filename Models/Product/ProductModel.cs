using System.Collections.Generic;

namespace APICatalogo.Models.Product
{
    public class ProductModel
    {
        public List<Product> products { get; set; }
    }

    public class Product
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int IdProduct { get; set; }
    }
}