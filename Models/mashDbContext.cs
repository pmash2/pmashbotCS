using Microsoft.EntityFrameworkCore;

namespace pmashbotCS.Models
{
    public class mashDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<WinLoss> WinLoss { get; set; }
        public DbSet<TodaysMessage> TodaysMessage { get; set; }
        public DbSet<UserPoints> UserPoints { get; set; }
        public DbSet<TransactionLog> TransactionLog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./mashDbContext.sqlite");
        }
    }
}
