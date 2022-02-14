using Microsoft.EntityFrameworkCore;

namespace SampleMVCApplication.Models
{
    public class ShopContext : IdentityDBContext<Customer>
    {
        public ShopContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; } //here you are able to name the table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //to insert value while connecting to db
            modelBuilder.Entity<Customer>().HasData(
                new Customer()
                {
                    Id = 101,
                    Name = "Bob",
                    Age = 21
                },
                new Customer()
                {
                    Id = 102,
                    Name = "Sarah",
                    Age = 22
                });
        }
    }
}
