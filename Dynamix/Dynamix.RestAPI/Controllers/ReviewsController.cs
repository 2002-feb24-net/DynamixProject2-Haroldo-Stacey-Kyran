using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dynamix.API.Models;
using Dynamix.API.Interfaces;
using Dynamix.API.Repositories;

namespace Dynamix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly DbDynamixContext _context;
        private readonly IReviewRepository reviewRepo;

        // This controller is decoupled from DbContext except for the PUT method

        public ReviewsController(DbDynamixContext context, IReviewRepository reviewRepository)
        {
            _context = context;
            reviewRepo = reviewRepository;
        }

        // GET: api/Reviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReview()
        {
            var list = await reviewRepo.ToListAsync();
            return Ok(list);
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            var review = await reviewRepo.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, Review review)
        {
            if (id != review.ReviewId)
            {
                return BadRequest();
            }

            // ef core 
            // _context.Entry(review).State = EntityState.Modified;

            _context.Entry(review).State = EntityState.Modified;

            try
            {
                await reviewRepo.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Reviews
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(Review review)
        {
            reviewRepo.Add(review);
            await reviewRepo.SaveChangesAsync();

            return CreatedAtAction("GetReview", new { id = review.ReviewId }, review);
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Review>> DeleteReview(int id)
        {
            var review = await reviewRepo.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            reviewRepo.Remove(review);
            await reviewRepo.SaveChangesAsync();

            return review;
        }

        private bool ReviewExists(int id)
        {
            return reviewRepo.Any(e => e.ReviewId == id);
        }
    }
}
