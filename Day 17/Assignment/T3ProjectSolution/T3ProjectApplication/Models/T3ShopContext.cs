using Microsoft.EntityFrameworkCore;

namespace T3ProjectApplication.Models
{
    public class T3ShopContext : DbContext
    {
        public T3ShopContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

    }
}
