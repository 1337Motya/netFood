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
    public class PizzaDoughTypesController : ControllerBase
    {
        private readonly netFoodDbContext _context;

        public PizzaDoughTypesController(netFoodDbContext context)
        {
            _context = context;
        }

        // GET: api/PizzaDoughTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaDoughType>>> GetPizzaDoughTypes()
        {
            return await _context.PizzaDoughTypes.ToListAsync();
        }

        // GET: api/PizzaDoughTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaDoughType>> GetPizzaDoughType(int id)
        {
            var pizzaDoughType = await _context.PizzaDoughTypes.FindAsync(id);

            if (pizzaDoughType == null)
            {
                return NotFound();
            }

            return pizzaDoughType;
        }

        // PUT: api/PizzaDoughTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizzaDoughType(int id, PizzaDoughType pizzaDoughType)
        {
            if (id != pizzaDoughType.Id)
            {
                return BadRequest();
            }

            _context.Entry(pizzaDoughType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaDoughTypeExists(id))
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

        // POST: api/PizzaDoughTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PizzaDoughType>> PostPizzaDoughType(PizzaDoughType pizzaDoughType)
        {
            _context.PizzaDoughTypes.Add(pizzaDoughType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPizzaDoughType", new { id = pizzaDoughType.Id }, pizzaDoughType);
        }

        // DELETE: api/PizzaDoughTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PizzaDoughType>> DeletePizzaDoughType(int id)
        {
            var pizzaDoughType = await _context.PizzaDoughTypes.FindAsync(id);
            if (pizzaDoughType == null)
            {
                return NotFound();
            }

            _context.PizzaDoughTypes.Remove(pizzaDoughType);
            await _context.SaveChangesAsync();

            return pizzaDoughType;
        }

        private bool PizzaDoughTypeExists(int id)
        {
            return _context.PizzaDoughTypes.Any(e => e.Id == id);
        }
    }
}
