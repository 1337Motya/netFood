using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetFood.Models;

namespace NetFood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaOrdersController : ControllerBase
    {
        private readonly netFoodDbContext _context;

        public PizzaOrdersController(netFoodDbContext context)
        {
            _context = context;
        }

        // GET: api/PizzaOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaOrder>>> GetPizzaOrders()
        {
            return await _context.PizzaOrders.ToListAsync();
        }

        // GET: api/PizzaOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaOrder>> GetPizzaOrder(int id)
        {
            var pizzaOrder = await _context.PizzaOrders.FindAsync(id);

            if (pizzaOrder == null)
            {
                return NotFound();
            }

            return pizzaOrder;
        }

        // PUT: api/PizzaOrders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizzaOrder(int id, PizzaOrder pizzaOrder)
        {
            if (id != pizzaOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(pizzaOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaOrderExists(id))
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

        // POST: api/PizzaOrders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PizzaOrder>> PostPizzaOrder(PizzaOrder pizzaOrder)
        {
            _context.PizzaOrders.Add(pizzaOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPizzaOrder", new { id = pizzaOrder.Id }, pizzaOrder);
        }

        // DELETE: api/PizzaOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PizzaOrder>> DeletePizzaOrder(int id)
        {
            var pizzaOrder = await _context.PizzaOrders.FindAsync(id);
            if (pizzaOrder == null)
            {
                return NotFound();
            }

            _context.PizzaOrders.Remove(pizzaOrder);
            await _context.SaveChangesAsync();

            return pizzaOrder;
        }

        private bool PizzaOrderExists(int id)
        {
            return _context.PizzaOrders.Any(e => e.Id == id);
        }
    }
}
