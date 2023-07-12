using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using OrderFood.Models;
namespace OrderFood.Models
{
    public class OrderFoodDBContext : DbContext
    {
        public OrderFoodDBContext(DbContextOptions<OrderFoodDBContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            


            modelBuilder.Entity<Dish>()
                .Property(d => d.Price)
                .HasColumnType("decimal(18, 2)");

          

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
