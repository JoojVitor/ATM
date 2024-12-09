using Microsoft.EntityFrameworkCore;

namespace ATM.Models
{
    public class SaqueDbContext : DbContext
    {
        public SaqueDbContext(DbContextOptions<SaqueDbContext> options) : base(options) { }

        public DbSet<Saque> Saques { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Cartao> Cartoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Saque>()
                .HasOne(s => s.Conta)
                .WithMany()
                .HasForeignKey("ContaId");

            modelBuilder.Entity<Saque>()
                .HasOne(s => s.Cartao)
                .WithMany()
                .HasForeignKey("CartaoId");
        }
    }
}
