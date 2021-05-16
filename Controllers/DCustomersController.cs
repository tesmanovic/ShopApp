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
    public class DCustomersController : ControllerBase
    {
        private readonly ShopAppDBContext _context;

        public DCustomersController(ShopAppDBContext context)
        {
            _context = context;
        }

        // GET: api/DCustomers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DCustomer>>> GetDCustomer()
        {
            return await _context.Customer.ToListAsync();
        }

        // GET: api/DCustomers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DCustomer>> GetDCustomer(int id)
        {
            var dCustomer = await _context.Customer.FindAsync(id);

            if (dCustomer == null)
            {
                return NotFound();
            }

            return dCustomer;
        }

        // PUT: api/DCustomers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDCustomer(int id, DCustomer dCustomer)
        {
            dCustomer.Id = id;

            _context.Entry(dCustomer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DCustomerExists(id))
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

        // POST: api/DCustomers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("login")]
        public async Task<ActionResult<DCustomer>> PostDCustomer(CustomerDTO dto)
        {
            var customer = await _context.Customer.FirstOrDefaultAsync(c => c.Username == dto.Username && c.Password == dto.Password);


            if (customer != null)
            {
                return customer;
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/DCustomers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("signup")]
        public async Task<ActionResult<DCustomer>> SignUp(CustomerDTO dto)
        {
            var customer1 = await _context.Customer.FirstOrDefaultAsync(c => c.Username == dto.customer.Username);


            if (customer1 != null)
            {
                return NotFound(new { Message="Already exists user with this username."});
            }

            try
            {
                var newCustomer = new DCustomer()
                {
                    Username = dto.customer.Username,
                    Password = dto.customer.Password,
                    FirstName = dto.customer.FirstName,
                    LastName = dto.customer.LastName,
                    Email = dto.customer.Email,
                    Address = dto.customer.Address,
                    BillingAddress = dto.customer.BillingAddress,
                    OpenDate = DateTime.Now
                };
                _context.Customer.Add(newCustomer);

                await _context.SaveChangesAsync();
                var customerId = newCustomer.Id;
                return Ok(new { id = customerId });
            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }
        
        // DELETE: api/DCustomers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DCustomer>> DeleteDCustomer(int id)
        {
            var dCustomer = await _context.Customer.FindAsync(id);
            if (dCustomer == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(dCustomer);
            await _context.SaveChangesAsync();

            return dCustomer;
        }

        private bool DCustomerExists(int id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}
