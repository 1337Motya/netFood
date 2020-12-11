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
    public class SnacksController : ControllerBase
    {
        private readonly netFoodDbContext _context;

        public SnacksController(netFoodDbContext context)
        {
            _context = context;
        }

        // GET: api/Snacks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Snack>>> GetSnacks()
        {
            return await _context.Snacks.ToListAsync();
        }

        // GET: api/Snacks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Snack>> GetSnack(int id)
        {
            var snack = await _context.Snacks.FindAsync(id);

            if (snack == null)
            {
                return NotFound();
            }

            return snack;
        }

        // PUT: api/Snacks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSnack(int id, Snack snack)
        {
            if (id != snack.Id)
            {
                return BadRequest();
            }

            _context.Entry(snack).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SnackExists(id))
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

        // POST: api/Snacks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Snack>> PostSnack(Snack snack)
        {
            _context.Snacks.Add(snack);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSnack", new { id = snack.Id }, snack);
        }

        // DELETE: api/Snacks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Snack>> DeleteSnack(int id)
        {
            var snack = await _context.Snacks.FindAsync(id);
            if (snack == null)
            {
                return NotFound();
            }

            _context.Snacks.Remove(snack);
            await _context.SaveChangesAsync();

            return snack;
        }

        private bool SnackExists(int id)
        {
            return _context.Snacks.Any(e => e.Id == id);
        }
    }
}
