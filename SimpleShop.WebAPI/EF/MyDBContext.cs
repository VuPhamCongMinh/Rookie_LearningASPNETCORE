using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleShop.WebAPI.Entities;

namespace SimpleShop.WebAPI.EF
{
    public class MyDBContext : IdentityDbContext
    {
        public MyDBContext (DbContextOptions<MyDBContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
