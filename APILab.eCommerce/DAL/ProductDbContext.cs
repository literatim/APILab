using System.Data.Entity;
using APILab.eCommerce.Models;

namespace APILab.eCommerce.DAL
{
    public class ProductDbContext: DbContext
    {
        public ProductDbContext() : base("ProductContext")
        {
            Database.SetInitializer(new ProductDbInitializer());
        }

        public DbSet<Product> Products { get; set; }
    }
}