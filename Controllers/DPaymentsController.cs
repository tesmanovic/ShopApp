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
    public class DPaymentsController : ControllerBase
    {
        private readonly ShopAppDBContext _context;

        public DPaymentsController(ShopAppDBContext context)
        {
            _context = context;
        }

        // GET: api/DPayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DPayment>>> GetPayment()
        {
            return await _context.Payment.ToListAsync();
        }

        // GET: api/DPayments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DPayment>> GetDPayment(int id)
        {
            var dPayment = await _context.Payment.FindAsync(id);

            if (dPayment == null)
            {
                return NotFound();
            }

            return dPayment;
        }

        // PUT: api/DPayments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDPayment(int id, DPayment dPayment)
        {
            if (id != dPayment.Id)
            {
                return BadRequest();
            }

            _context.Entry(dPayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DPaymentExists(id))
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

        // POST: api/DPayments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("detailts")]
        public async Task<ActionResult<DPayment>> PostDPayment(PaymentDTO dto)
        {
            var customer = await _context.Customer.FirstOrDefaultAsync(c=>c.Id ==dto.CustomerId);
            var orderItems = await _context.OrderItem.Where(item => item.OrderId == dto.OrderId).ToListAsync();
            var stages = await _context.Stage.ToListAsync();
            var tickets = await _context.Ticket.ToListAsync();
            List<OrderItemDetails> list = new List<OrderItemDetails>();
                

            if (customer == null || orderItems == null)
                return NotFound();

            try
            {
                foreach (DOrderItem item in orderItems)
                {
                    var stageId = tickets.FirstOrDefault(t => t.Id == item.TicketId).StageId;
                    list.Add(new OrderItemDetails()
                    {
                        TicketId = item.TicketId,
                        OrderNumber = item.OrderNumber,
                        Quantity = item.Quantity,
                        Amount = item.Amount,
                        Price = tickets.FirstOrDefault(t => t.Id == item.TicketId).Price,
                        StageName = stages.FirstOrDefault(s => s.Id == stageId).Name
                    }); 
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }

            return Ok(new { customer1=customer, orderItems=list });
        }

        [HttpPost("new")]
        public async Task<ActionResult<DPayment>> PostNewDPayment(PaymentDTO dto)
        {
            try
            {
                var newPayment = new DPayment()
                {
                    CustomerId = dto.CustomerId,
                    OrderId = dto.OrderId,
                    TotalAmount = dto.Amount
                };

                _context.Payment.Add(newPayment);

                await _context.SaveChangesAsync();
                var paymentID = newPayment.Id;

                return Ok(new { id = paymentID });
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // DELETE: api/DPayments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DPayment>> DeleteDPayment(int id)
        {
            var dPayment = await _context.Payment.FindAsync(id);
            if (dPayment == null)
            {
                return NotFound();
            }

            _context.Payment.Remove(dPayment);
            await _context.SaveChangesAsync();

            return dPayment;
        }

        private bool DPaymentExists(int id)
        {
            return _context.Payment.Any(e => e.Id == id);
        }
    }
}
