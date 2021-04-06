using Microsoft.EntityFrameworkCore;
using SimpleShop.Shared.EF;
using SimpleShop.Shared.Interfaces;
using SimpleShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleShop.API.Services
{
    public class RatingService : IRatingService
    {
        private readonly MyDBContext context;

        public RatingService (MyDBContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Rating>> GetRatingByProductId (int id)
        {
            return await context.Ratings.Where(x => x.productId == id).ToListAsync();
        }
    }
}
