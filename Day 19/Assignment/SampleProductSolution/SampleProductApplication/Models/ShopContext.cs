using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProductApplication.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Customer>().HasData(
        //        new Customer() { Id = 101, Name = "Tim", Age = 23 },
        //        new Customer() { Id = 102, Name = "Jim", Age = 31 }
        //        );
        //}
    }
}
