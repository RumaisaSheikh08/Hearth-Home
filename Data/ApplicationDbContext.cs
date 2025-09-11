using Microsoft.EntityFrameworkCore;
using StoreEcommerce.Models;

namespace StoreEcommerce.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItems> OrderItems { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasKey(k => k.UserID);
            modelBuilder.Entity<Product>().HasKey(k => k.ProductId);
            modelBuilder.Entity<Order>().HasKey(k => k.OrderId);
            modelBuilder.Entity<OrderItems>().HasKey(k => k.OrderItemId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
