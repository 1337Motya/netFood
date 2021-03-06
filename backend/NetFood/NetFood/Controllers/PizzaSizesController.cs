﻿using System;
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
    public class PizzaSizesController : ControllerBase
    {
        private readonly netFoodDbContext _context;

        public PizzaSizesController(netFoodDbContext context)
        {
            _context = context;
        }

        // GET: api/PizzaSizes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaSize>>> GetPizzaSizes()
        {
            return await _context.PizzaSizes.ToListAsync();
        }

        // GET: api/PizzaSizes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaSize>> GetPizzaSize(int id)
        {
            var pizzaSize = await _context.PizzaSizes.FindAsync(id);

            if (pizzaSize == null)
            {
                return NotFound();
            }

            return pizzaSize;
        }

        // PUT: api/PizzaSizes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizzaSize(int id, PizzaSize pizzaSize)
        {
            if (id != pizzaSize.Id)
            {
                return BadRequest();
            }

            _context.Entry(pizzaSize).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaSizeExists(id))
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

        // POST: api/PizzaSizes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PizzaSize>> PostPizzaSize(PizzaSize pizzaSize)
        {
            _context.PizzaSizes.Add(pizzaSize);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPizzaSize", new { id = pizzaSize.Id }, pizzaSize);
        }

        // DELETE: api/PizzaSizes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PizzaSize>> DeletePizzaSize(int id)
        {
            var pizzaSize = await _context.PizzaSizes.FindAsync(id);
            if (pizzaSize == null)
            {
                return NotFound();
            }

            _context.PizzaSizes.Remove(pizzaSize);
            await _context.SaveChangesAsync();

            return pizzaSize;
        }

        private bool PizzaSizeExists(int id)
        {
            return _context.PizzaSizes.Any(e => e.Id == id);
        }
    }
}
