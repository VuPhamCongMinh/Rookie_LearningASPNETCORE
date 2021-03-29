using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Application.EF
{
    public class MyDBContext : DbContext
    {
        public MyDBContext (DbContextOptions<MyDBContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ImageStorage> ImageStorage { get; set; }

    }
}
