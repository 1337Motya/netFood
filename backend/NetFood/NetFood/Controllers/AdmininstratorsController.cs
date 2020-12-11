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
    public class AdmininstratorsController : ControllerBase
    {
        private readonly netFoodDbContext _context;

        public AdmininstratorsController(netFoodDbContext context)
        {
            _context = context;
        }

        // GET: api/Admininstrators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admininstrator>>> GetAdmininstrators()
        {
            return await _context.Admininstrators.ToListAsync();
        }

        // GET: api/Admininstrators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Admininstrator>> GetAdmininstrator(int id)
        {
            var admininstrator = await _context.Admininstrators.FindAsync(id);

            if (admininstrator == null)
            {
                return NotFound();
            }

            return admininstrator;
        }

        // PUT: api/Admininstrators/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmininstrator(int id, Admininstrator admininstrator)
        {
            if (id != admininstrator.Id)
            {
                return BadRequest();
            }

            _context.Entry(admininstrator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdmininstratorExists(id))
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

        // POST: api/Admininstrators
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Admininstrator>> PostAdmininstrator(Admininstrator admininstrator)
        {
            _context.Admininstrators.Add(admininstrator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdmininstrator", new { id = admininstrator.Id }, admininstrator);
        }

        // DELETE: api/Admininstrators/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Admininstrator>> DeleteAdmininstrator(int id)
        {
            var admininstrator = await _context.Admininstrators.FindAsync(id);
            if (admininstrator == null)
            {
                return NotFound();
            }

            _context.Admininstrators.Remove(admininstrator);
            await _context.SaveChangesAsync();

            return admininstrator;
        }

        private bool AdmininstratorExists(int id)
        {
            return _context.Admininstrators.Any(e => e.Id == id);
        }
    }
}
