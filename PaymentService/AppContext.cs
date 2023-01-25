using Microsoft.EntityFrameworkCore;
using PaymentService.Models;

namespace PaymentService
{
    public class AppContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "PaymentDB");
        }

        public DbSet<Payment> Payments { get; set; }
    }
}
