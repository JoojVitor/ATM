using Microsoft.EntityFrameworkCore;

namespace ATM.Models
{
    public class ContaDbContext : DbContext
    {
        public DbSet<Conta> Contas { get; set; }

        public ContaDbContext(DbContextOptions<ContaDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conta>().HasKey(c => c.Codigo);
            base.OnModelCreating(modelBuilder);
        }
    }
}
