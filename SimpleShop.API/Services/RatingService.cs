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
        public async Task<IEnumerable<Rating>> GetRatings ()
        {
            return await context.Ratings.ToListAsync();
        }
        public async Task<IEnumerable<Rating>> GetRatingByProductId (int id)
        {
            return await context.Ratings.Where(x => x.productId == id).Include(rt => rt.User).ToListAsync();
        }

        public async Task<Rating> PostRating (string userId, int productId, string comment, int rateValue)
        {
            var ratingToBeAdded = new Rating { userId = userId, productId = productId, comment = comment, rateValue = rateValue, createdDate = DateTime.Now, updatedDate = DateTime.Now };

            try
            {
                await context.Ratings.AddAsync(ratingToBeAdded);
                await context.SaveChangesAsync();
                return ratingToBeAdded;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Rating> PutRating (int id, string userId, int productId, string comment, int rateValue)
        {
            var ratingToBeUpdated = await context.Ratings.FindAsync(id);

            if (ratingToBeUpdated is null)
            {
                return null;
            }

            try
            {
                ratingToBeUpdated.userId = userId;
                ratingToBeUpdated.productId = productId;
                ratingToBeUpdated.comment = comment;
                ratingToBeUpdated.rateValue = rateValue;
                await context.SaveChangesAsync();
                return ratingToBeUpdated;
            }
            catch (System.Exception e)
            {
                return null;
            }
        }
    }
}
