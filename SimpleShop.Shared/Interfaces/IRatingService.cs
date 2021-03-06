using SimpleShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.Shared.Interfaces
{
    public interface IRatingService
    {
        public Task<IEnumerable<Rating>> GetRatings ();
        public Task<IEnumerable<Rating>> GetRatingByProductId (int id);
        public Task<Rating> PostRating (string userId, int productId, string comment, int rateValue);
        public Task<Rating> PutRating (int id, string userId, int productId, string comment, int rateValue);
    }
}
