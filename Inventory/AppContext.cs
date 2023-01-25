using InventoryService.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryService
{
    public class AppContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "InventoryDB");
        }

        public DbSet<Inventory> Inventories { get; set; }
    }
}
