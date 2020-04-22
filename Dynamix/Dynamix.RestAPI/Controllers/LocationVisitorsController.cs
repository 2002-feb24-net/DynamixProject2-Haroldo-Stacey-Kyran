using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dynamix.API.Models;

namespace Dynamix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationVisitorsController : ControllerBase
    {
        private readonly DbDynamixContext _context;

        public LocationVisitorsController(DbDynamixContext context)
        {
            _context = context;
        }

        // GET: api/LocationVisitors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationVisitor>>> GetLocationVisitor()
        {
            return await _context.LocationVisitor.ToListAsync();
        }

        // GET: api/LocationVisitors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocationVisitor>> GetLocationVisitor(int id)
        {
            var locationVisitor = await _context.LocationVisitor.FindAsync(id);

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
                await _context.SaveChangesAsync();
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
                await _context.SaveChangesAsync();
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
            var locationVisitor = await _context.LocationVisitor.FindAsync(id);
            if (locationVisitor == null)
            {
                return NotFound();
            }

            _context.LocationVisitor.Remove(locationVisitor);
            await _context.SaveChangesAsync();

            return locationVisitor;
        }

        private bool LocationVisitorExists(int id)
        {
            return _context.LocationVisitor.Any(e => e.LocationVisitorId == id);
        }
    }
}
