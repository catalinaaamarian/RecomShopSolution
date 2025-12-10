using Microsoft.EntityFrameworkCore;
using RecomShop.WebMVC.Models;

namespace RecomShop.WebMVC.Data
{
    public class RecomShopContext : DbContext
    {
        public RecomShopContext(DbContextOptions<RecomShopContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
