using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dynamix.API.Models;
using Dynamix.API.Interfaces;

namespace Dynamix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationVisitorsController : ControllerBase
    {
        private readonly DbDynamixContext _context;
        private readonly ILocationVisitorRepository locationVisitorRepo;

        // This controller is decoupled from DbContext except for the PUT method


        public LocationVisitorsController(DbDynamixContext context, ILocationVisitorRepository locationVisitorRepository)
        {
            _context = context;
            locationVisitorRepo = locationVisitorRepository;
        }

        // GET: api/LocationVisitors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationVisitor>>> GetLocationVisitor()
        {
            var list = await locationVisitorRepo.ToListAsync();
            return Ok(list);
        }

        // GET: api/LocationVisitors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocationVisitor>> GetLocationVisitor(int id)
        {
            var locationVisitor = await locationVisitorRepo.FindAsync(id);

            if (locationVisitor == null)
            {
                return NotFound();
            }

            return locationVisitor;
        }

        // PUT: api/LocationVisitors/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocationVisitor(int id, LocationVisitor locationVisitor)
        {
            if (id != locationVisitor.LocationVisitorId)
            {
                return BadRequest();
            }

            _context.Entry(locationVisitor).State = EntityState.Modified;

            try
            {
                await locationVisitorRepo.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationVisitorExists(id))
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

        // POST: api/LocationVisitors
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<LocationVisitor>> PostLocationVisitor(LocationVisitor locationVisitor)
        {
            _context.LocationVisitor.Add(locationVisitor);
            try
            {
                await locationVisitorRepo.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LocationVisitorExists(locationVisitor.LocationVisitorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLocationVisitor", new { id = locationVisitor.LocationVisitorId }, locationVisitor);
        }

        // DELETE: api/LocationVisitors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LocationVisitor>> DeleteLocationVisitor(int id)
        {
            var locationVisitor = await locationVisitorRepo.FindAsync(id);
            if (locationVisitor == null)
            {
                return NotFound();
            }

            locationVisitorRepo.Remove(locationVisitor);
            await locationVisitorRepo.SaveChangesAsync();

            return locationVisitor;
        }

        private bool LocationVisitorExists(int id)
        {
            return locationVisitorRepo.Any(e => e.LocationVisitorId == id);
        }
    }
}
