using Microsoft.EntityFrameworkCore;
using Northwind.Ordering.Data.Database.Dto;

namespace Northwind.Ordering.Data.Database
{
    public class NorthwindDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public NorthwindDbContext(DbContextOptions options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey("ProductID");
            
            modelBuilder.Entity<Order>().HasKey("OrderID");
            modelBuilder.Entity<Order>().HasMany("OrderDetails").WithOne("Order");

            // composite primary key.
            modelBuilder.Entity<OrderDetail>().HasKey(od => new { od.OrderID, od.ProductID });
            modelBuilder.Entity<OrderDetail>().HasOne(c => c.Product);

            base.OnModelCreating(modelBuilder);
        }

    }
}
