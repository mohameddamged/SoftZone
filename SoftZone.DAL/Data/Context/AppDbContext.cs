using Microsoft.EntityFrameworkCore;

namespace SoftZone.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply configurations if any, or use Fluent API here
            modelBuilder.Entity<MenuItem>().Property(m => m.Price).HasPrecision(18, 2);
            modelBuilder.Entity<Order>().Property(o => o.TotalAmount).HasPrecision(18, 2);
            modelBuilder.Entity<OrderItem>().Property(oi => oi.UnitPrice).HasPrecision(18, 2);
            modelBuilder.Entity<OrderItem>().Property(oi => oi.TotalPrice).HasPrecision(18, 2);

            // Call Seed Data from Seeders Folder
            RestaurantSeeder.Seed(modelBuilder);
        }
    }
}
