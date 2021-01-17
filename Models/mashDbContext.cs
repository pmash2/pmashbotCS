using Microsoft.EntityFrameworkCore;

namespace pmashbotCS.Models
{
    public class mashDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<WinLoss> WinLoss { get; set; }
        public DbSet<TodaysMessage> TodaysMessage { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./mashDbContext.sqlite");
        }
    }
}
