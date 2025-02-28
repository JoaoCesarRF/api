using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<SaleItem> SaleItem { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
