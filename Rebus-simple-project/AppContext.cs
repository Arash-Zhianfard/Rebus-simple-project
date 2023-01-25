using Microsoft.EntityFrameworkCore;
using OrderService.Models;

namespace OrderService
{
    public class AppContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "OrderDB");
        }

        public DbSet<Order> Orders { get; set; }
    }
}
