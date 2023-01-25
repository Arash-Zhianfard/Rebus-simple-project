using Microsoft.EntityFrameworkCore;
using Rebus_simple_project.Models;

namespace Rebus_simple_project
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
