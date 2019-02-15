using System.Collections.Generic;
using System.Data.Entity;

namespace APILab.Inventory.DAL
{
    public class InventoryDbInitializer: CreateDatabaseIfNotExists<InventoryDbContext>
    {
        protected override void Seed(InventoryDbContext context)
        {
            var products = new List<Models.Inventory>()
            {
                new Models.Inventory {Id = 1, Quantity = 2},
                new Models.Inventory {Id = 2, Quantity = 3},
                new Models.Inventory {Id = 3, Quantity = 6}
            };

            context.Inventories.AddRange(products);
            context.SaveChanges();
        }
    }
}