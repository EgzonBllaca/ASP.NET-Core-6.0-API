using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.NET_Core_6._0_API.Entities;

namespace ASP.NET_Core_6._0_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerberesiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PerberesiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Perberesi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Perberesi>>> GetPerberesis()
        {
          if (_context.Perberesis == null)
          {
              return NotFound();
          }
            return await _context.Perberesis.ToListAsync();
        }

        // GET: api/Perberesi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Perberesi>> GetPerberesi(int id)
        {
          if (_context.Perberesis == null)
          {
              return NotFound();
          }
            var perberesi = await _context.Perberesis.FindAsync(id);

            if (perberesi == null)
            {
                return NotFound();
            }

            return perberesi;
        }

        // PUT: api/Perberesi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerberesi(int id, Perberesi perberesi)
        {
            if (id != perberesi.Id)
            {
                return BadRequest();
            }

            _context.Entry(perberesi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerberesiExists(id))
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

        // POST: api/Perberesi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Perberesi>> PostPerberesi(Perberesi perberesi)
        {
          if (_context.Perberesis == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Perberesis'  is null.");
          }
            _context.Perberesis.Add(perberesi);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PerberesiExists(perberesi.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPerberesi", new { id = perberesi.Id }, perberesi);
        }

        // DELETE: api/Perberesi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerberesi(int id)
        {
            if (_context.Perberesis == null)
            {
                return NotFound();
            }
            var perberesi = await _context.Perberesis.FindAsync(id);
            if (perberesi == null)
            {
                return NotFound();
            }

            _context.Perberesis.Remove(perberesi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PerberesiExists(int id)
        {
            return (_context.Perberesis?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
