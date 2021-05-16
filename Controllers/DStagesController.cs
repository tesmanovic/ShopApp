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
    public class DStagesController : ControllerBase
    {
        private readonly ShopAppDBContext _context;

        public DStagesController(ShopAppDBContext context)
        {
            _context = context;
        }

        // GET: api/DStages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DStage>>> GetStage()
        {
            return await _context.Stage.ToListAsync();
        }

        // GET: api/DStages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DStage>> GetDStage(int id)
        {
            var dStage = await _context.Stage.FindAsync(id);

            if (dStage == null)
            {
                return NotFound();
            }

            return dStage;
        }

        // GET: api/DStages/festival/5
        [HttpGet("festival/{id}")]
        public async Task<ActionResult<IEnumerable<DStage>>> GetDStageByFestival(int id)
        {
            var dStage = await _context.Stage.Where(s => s.Festival.Id == id).ToListAsync();

            if (dStage == null)
            {
                return NotFound();
            }

            return dStage;
        }

        // PUT: api/DStages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDStage(int id, DStage dStage)
        {
            if (id != dStage.Id)
            {
                return BadRequest();
            }

            _context.Entry(dStage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DStageExists(id))
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

        // POST: api/DStages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DStage>> PostDStage(DStage dStage)
        {
            _context.Stage.Add(dStage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDStage", new { id = dStage.Id }, dStage);
        }

        // DELETE: api/DStages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DStage>> DeleteDStage(int id)
        {
            var dStage = await _context.Stage.FindAsync(id);
            if (dStage == null)
            {
                return NotFound();
            }

            _context.Stage.Remove(dStage);
            await _context.SaveChangesAsync();

            return dStage;
        }

        private bool DStageExists(int id)
        {
            return _context.Stage.Any(e => e.Id == id);
        }
    }
}
