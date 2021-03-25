using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleShop.WebAPI.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options: options)
        {

        }


    }
}
