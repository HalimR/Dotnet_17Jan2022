using Microsoft.EntityFrameworkCore;

namespace ProductAPI.Models
{
    public class SampleContext : DbContext
    {
        public SampleContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Product> Products { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, Name = "Pizza", Price = 12.56, Quantity = 21 },
            new Product() { Id = 2, Name = "Dictionary", Price = 56.42, Quantity = 4 },
            new Product() { Id = 3, Name = "Laptop", Price = 502.24, Quantity = 7 });
        }
    }
}
