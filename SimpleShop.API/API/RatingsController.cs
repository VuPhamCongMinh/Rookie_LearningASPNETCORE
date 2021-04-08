using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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

        //// GET: api/Ratings
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Rating>>> GetRatings()
        //{
        //    return await _context.Ratings.ToListAsync();
        //}

        // GET: api/Ratings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<RatingResponse>>> GetRatingByProductId (int id)
        {
            var ratingsFromDB = await ratingService.GetRatingByProductId(id);
            var ratings = mapper.Map<IEnumerable<RatingResponse>>(ratingsFromDB);

            return Ok(ratings);
        }

        //// PUT: api/Ratings/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutRating(int id, Rating rating)
        //{
        //    if (id != rating.ratingId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(rating).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RatingExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Ratings
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        //private bool RatingExists(int id)
        //{
        //    return _context.Ratings.Any(e => e.ratingId == id);
        //}
    }
}
