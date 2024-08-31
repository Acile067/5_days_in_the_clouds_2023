using Microsoft.EntityFrameworkCore;
using Levi9_competition.Models;

namespace Levi9_competition.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; } = default!;
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>()
                .HasKey(p => p.FullName);
            modelBuilder.Entity<Player>()
                .Property(p => p.FullName)
                .HasMaxLength(100);
        }
    }
}
