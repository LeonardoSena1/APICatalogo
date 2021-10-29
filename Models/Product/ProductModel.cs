using APICatalogo.ValidatorModels;
using System;
using System.Collections.Generic;

namespace APICatalogo.Models.Product
{
    public class ProductModel
    {
        public List<Product> products { get; set; }
    }

    public class Product : Entity
    {
        public Product(string title, decimal price, int idProduct)
        {
            Id = Guid.NewGuid();
            this.Title = title;
            this.Price = price;
            this.IdProduct = idProduct;

            Validate(this, new ValidatorProduct());
        }

        public string Title { get; set; }
        public decimal Price { get; set; }
        public int IdProduct { get; set; }
    }
}