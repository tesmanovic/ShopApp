using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApp.Models;
using ShopApp.Models.DTO;

namespace ShopApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DOrdersController : ControllerBase
    {
        private readonly ShopAppDBContext _context;

        public DOrdersController(ShopAppDBContext context)
        {
            _context = context;
        }

        // GET: api/DOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DOrder>>> GetOrder()
        {
            return await _context.Order.ToListAsync();
        }

        // GET: api/DOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DOrder>> GetDOrder(int id)
        {
            var dOrder = await _context.Order.FindAsync(id);

            if (dOrder == null)
            {
                return NotFound();
            }

            return dOrder;
        }

        // PUT: api/DOrders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("addorder")]
        public async Task<IActionResult> PostDOrder(OrderItemDTO dto)
        {
            var status = await _context.OrderStatus.FirstOrDefaultAsync(s => s.Description == "NEW");

            _context.Entry(status).State = EntityState.Detached;

           var newOrder = new DOrder()
           {
               OpenDate = DateTime.Now,
               CustomerId = dto.IdCustomer,
               OrderStatusId = status.Id,

           };
            _context.Order.Add(newOrder);


            try
            {
                await _context.SaveChangesAsync();
                var idOrder = newOrder.Id;

                foreach (DOrderItem item in dto.Items)
                {
                    item.OrderId = idOrder;
                    _context.OrderItem.Add(item);
                    await _context.SaveChangesAsync();
                }
                return Ok(new { idOrder});
            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }

        // POST: api/DOrders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DOrder>> PostDOrder(DOrder dOrder)
        {
            _context.Order.Add(dOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDOrder", new { id = dOrder.Id }, dOrder);
        }

        // DELETE: api/DOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DOrder>> DeleteDOrder(int id)
        {
            var dOrder = await _context.Order.FindAsync(id);
            if (dOrder == null)
            {
                return NotFound();
            }

            _context.Order.Remove(dOrder);
            await _context.SaveChangesAsync();

            return dOrder;
        }

        private bool DOrderExists(int id)
        {
            return _context.Order.Any(e => e.Id == id);
        }
    }
}
