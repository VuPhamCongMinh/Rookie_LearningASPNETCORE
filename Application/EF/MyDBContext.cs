using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Application.EF
{
    public class MyDBContext : IdentityDbContext
    {
        public MyDBContext (DbContextOptions<MyDBContext> options) : base(options: options)
        {

        }
        public DbSet<Product> Products { get; set; }

    }
}
