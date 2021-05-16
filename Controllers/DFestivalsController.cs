using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApp.Models;

namespace ShopApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DFestivalsController : ControllerBase
    {
        private readonly ShopAppDBContext _context;

        public DFestivalsController(ShopAppDBContext context)
        {
            _context = context;
        }

        // GET: api/DFestivals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DFestival>>> GetFestival()
        {
            var pom =  await _context.Festival.ToListAsync();

            foreach (DFestival f in pom)
            {
                f.DateFrom = f.DateFrom.ToUniversalTime();
                f.DateEnd = f.DateEnd.ToUniversalTime();
            }
            return pom;
        }

        // GET: api/DFestivals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DFestival>> GetDFestival(int id)
        {
            var dFestival = await _context.Festival.FindAsync(id);

            if (dFestival == null)
            {
                return NotFound();
            }

            return dFestival;
        }

        // PUT: api/DFestivals/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDFestival(int id, DFestival dFestival)
        {
            if (id != dFestival.Id)
            {
                return BadRequest();
            }

            _context.Entry(dFestival).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DFestivalExists(id))
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

        // POST: api/DFestivals
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DFestival>> PostDFestival(DFestival dFestival)
        {
            _context.Festival.Add(dFestival);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDFestival", new { id = dFestival.Id }, dFestival);
        }

        // DELETE: api/DFestivals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DFestival>> DeleteDFestival(int id)
        {
            var dFestival = await _context.Festival.FindAsync(id);
            if (dFestival == null)
            {
                return NotFound();
            }

            _context.Festival.Remove(dFestival);
            await _context.SaveChangesAsync();

            return dFestival;
        }

        private bool DFestivalExists(int id)
        {
            return _context.Festival.Any(e => e.Id == id);
        }
    }
}
