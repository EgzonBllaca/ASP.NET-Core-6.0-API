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
    public class RecetaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RecetaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Receta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receta>>> GetReceta()
        {
          if (_context.Receta == null)
          {
              return NotFound();
          }
            return await _context.Receta.ToListAsync();
        }

        // GET: api/Receta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Receta>> GetReceta(int id)
        {
          if (_context.Receta == null)
          {
              return NotFound();
          }
            var receta = await _context.Receta.FindAsync(id);

            if (receta == null)
            {
                return NotFound();
            }

            return receta;
        }

        // PUT: api/Receta/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceta(int id, Receta receta)
        {
            if (id != receta.Id)
            {
                return BadRequest();
            }

            _context.Entry(receta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecetaExists(id))
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

        // POST: api/Receta
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Receta>> PostReceta(Receta receta)
        {
          if (_context.Receta == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Receta'  is null.");
          }
            _context.Receta.Add(receta);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RecetaExists(receta.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetReceta", new { id = receta.Id }, receta);
        }

        // DELETE: api/Receta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceta(int id)
        {
            if (_context.Receta == null)
            {
                return NotFound();
            }
            var receta = await _context.Receta.FindAsync(id);
            if (receta == null)
            {
                return NotFound();
            }

            _context.Receta.Remove(receta);
            await _context.SaveChangesAsync();

            return Ok("Deleted successfully!");
        }

        private bool RecetaExists(int id)
        {
            return (_context.Receta?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
