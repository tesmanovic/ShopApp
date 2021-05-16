using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApp.Models;

namespace ShopApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DTicketsController : ControllerBase
    {
        private readonly ShopAppDBContext _context;

        public DTicketsController(ShopAppDBContext context)
        {
            _context = context;
        }

        // GET: api/DTickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTicket>>> GetTicket()
        {
            return await _context.Ticket.ToListAsync();
        }

        // GET: api/DTickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DTicket>> GetDTicket(int id)
        {
            var dTicket = await _context.Ticket.FindAsync(id);

            if (dTicket == null)
            {
                return NotFound();
            }

            return dTicket;
        }

        // GET: api/DTickets/stages/5
        [HttpGet("stages/{id}")]
        public async Task<ActionResult<IEnumerable<DTicket>>> GetDTicketByStage(int id)
        {
            var dTicket = await _context.Ticket.Where(t => t.Stage.Id == id).ToListAsync();

            if (dTicket == null)
            {
                return NotFound();
            }

            return dTicket;
        }

        // PUT: api/DTickets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDTicket(int id, DTicket dTicket)
        {
            if (id != dTicket.Id)
            {
                return BadRequest();
            }

            _context.Entry(dTicket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DTicketExists(id))
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

        // POST: api/DTickets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DTicket>> PostDTicket(DTicket dTicket)
        {
            _context.Ticket.Add(dTicket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDTicket", new { id = dTicket.Id }, dTicket);
        }

        // DELETE: api/DTickets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DTicket>> DeleteDTicket(int id)
        {
            var dTicket = await _context.Ticket.FindAsync(id);
            if (dTicket == null)
            {
                return NotFound();
            }

            _context.Ticket.Remove(dTicket);
            await _context.SaveChangesAsync();

            return dTicket;
        }

        private bool DTicketExists(int id)
        {
            return _context.Ticket.Any(e => e.Id == id);
        }
    }
}
