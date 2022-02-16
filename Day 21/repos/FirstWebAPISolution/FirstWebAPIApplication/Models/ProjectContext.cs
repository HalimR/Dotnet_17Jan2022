using Microsoft.EntityFrameworkCore;

namespace FirstWebAPIApplication.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

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
