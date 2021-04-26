using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleShop.Shared.Interfaces;
using SimpleShop.Shared.Models;
using SimpleShop.Shared.ViewModels;

namespace SimpleShop.API.API
{
 
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingService ratingService;
        private readonly IMapper mapper;

        public RatingsController (IRatingService ratingService, IMapper mapper)
        {
            this.ratingService = ratingService;
            this.mapper = mapper;
        }

        // GET: api/Ratings
        [Authorize("Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rating>>> GetRatings ()
        {
            var rating = await ratingService.GetRatings();
            if (rating is null)
            {
                return NotFound();
            }
            return Ok(rating);
        }

        // GET: api/Ratings/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<RatingResponse>>> GetRatingByProductId (int id)
        {
            var ratingsFromDB = await ratingService.GetRatingByProductId(id);
            var ratings = mapper.Map<IEnumerable<RatingResponse>>(ratingsFromDB);

            return Ok(ratings);
        }

        // PUT: api/Ratings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize("Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRating (int id, [FromForm] string userId, [FromForm] int productId, [FromForm] int rateValue, [FromForm] string comment)
        {
            var product = await ratingService.PutRating(id, userId, productId, comment, rateValue);

            if (product is null)
            {
                return BadRequest();
            }
            return Ok(product);
        }

        //// POST: api/Ratings
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize("User")]
        [HttpPost]
        public async Task<ActionResult<Rating>> PostRating ([FromForm] string userId, [FromForm] int productId, [FromForm] int rateValue, [FromForm] string comment)
        {
            var rating = await ratingService.PostRating(userId, productId, comment, rateValue);
            if (rating != null)
            {
                return CreatedAtAction("GetRating", new { id = rating.ratingId }, rating);
            }
            return BadRequest();

        }

        //// DELETE: api/Ratings/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteRating(int id)
        //{
        //    var rating = await _context.Ratings.FindAsync(id);
        //    if (rating == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Ratings.Remove(rating);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}


    }
}
