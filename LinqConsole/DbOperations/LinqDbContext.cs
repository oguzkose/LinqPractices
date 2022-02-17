using LinqConsole.Entity;
using Microsoft.EntityFrameworkCore;

namespace LinqConsole.DbOperations
{
    public class LinqDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName:"LinqDatabase");
        }
        public DbSet<Student> Students { get; set; }
    }
}