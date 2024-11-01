using Microsoft.EntityFrameworkCore;

namespace ATM.Models
{
    public class SaqueDbContext : DbContext
    {
        public DbSet<Saque> Saques { get; set; }

        public SaqueDbContext(DbContextOptions<SaqueDbContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Saque>().HasKey(s => s.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
