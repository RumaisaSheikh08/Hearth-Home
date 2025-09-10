using Microsoft.EntityFrameworkCore;
using StoreEcommerce.Models;

namespace StoreEcommerce.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasKey(k => k.UserID);
            modelBuilder.Entity<Product>().HasKey(k => k.ProductId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
