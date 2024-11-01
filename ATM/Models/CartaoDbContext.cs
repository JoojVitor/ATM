using Microsoft.EntityFrameworkCore;

namespace ATM.Models
{
    public class CartaoDbContext : DbContext
    {
        public DbSet<Cartao> Cartoes { get; set; }

        public CartaoDbContext(DbContextOptions<CartaoDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cartao>().HasKey(c => c.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
