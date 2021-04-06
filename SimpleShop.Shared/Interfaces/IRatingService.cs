using SimpleShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.Shared.Interfaces
{
    public interface IRatingService
    {
        public Task<IEnumerable<Rating>> GetRatingByProductId (int id);
    }
}
