using System.Collections.Generic;
using System.Data.Entity;
using APILab.eCommerce.Models;

namespace APILab.eCommerce.DAL
{
    public class ProductDbInitializer : CreateDatabaseIfNotExists<ProductDbContext>
    {
        protected override void Seed(ProductDbContext context)
        {
            var products = new List<Product>()
            {
                new Product {ItemId = 1, Name = "Dusty hot pocket", Description = "old cheezi boi", Price = 5.00},
                new Product {ItemId = 2, Name = "Bean chair", Description = "Either a bean bag chair or a chair covered in beans", Price = 420.00},
                new Product {ItemId = 3, Name = "Beans", Description = "We found beans all over a chair so we're selling separately - limited time offer", Price = 1.00}
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}