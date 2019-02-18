using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace APILab.Inventory.DAL
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext() : base("InventoryContext")
        {
            Database.SetInitializer(new InventoryDbInitializer());
        }

        public DbSet<Models.Inventory> Inventories { get; set; }

        public System.Data.Entity.DbSet<APILab.Inventory.Models.Order> Orders { get; set; }
    }
}