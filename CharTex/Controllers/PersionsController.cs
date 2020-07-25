using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharTex.Models;

namespace CharTex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersionsController : ControllerBase
    {
        private readonly Chartex_Context _context;

        public PersionsController(Chartex_Context context)
        {
            _context = context;
        }

        // GET: api/Persions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persions>>> Get_Persions()
        {
            var ali = _context._Chartex_Views.ToList();
           return await _context._Persions.ToListAsync();
           // return await _context._Chartex_Views.ToListAsync();
        }

        // GET: api/Persions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persions>> GetPersions(int id)
        {
            var persions = await _context._Persions.FindAsync(id);

            if (persions == null)
            {
                return NotFound();
            }

            return persions;
        }

        // PUT: api/Persions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersions(int id, Persions persions)
        {
            if (id != persions.id)
            {
                return BadRequest();
            }

            _context.Entry(persions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersionsExists(id))
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

        // POST: api/Persions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Persions>> PostPersions(Persions persions)
        {
            _context._Persions.Add(persions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersions", new { id = persions.id }, persions);
        }

        // DELETE: api/Persions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Persions>> DeletePersions(int id)
        {
            var persions = await _context._Persions.FindAsync(id);
            if (persions == null)
            {
                return NotFound();
            }

            _context._Persions.Remove(persions);
            await _context.SaveChangesAsync();

            return persions;
        }

        private bool PersionsExists(int id)
        {
            return _context._Persions.Any(e => e.id == id);
        }
    }
}
