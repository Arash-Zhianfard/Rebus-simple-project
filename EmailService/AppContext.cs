using EmailService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailService
{
    public class AppContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "EmailDB");
        }

        public DbSet<Email> Emails { get; set; }
    }
}
