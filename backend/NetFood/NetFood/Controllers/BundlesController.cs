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
    public class BundlesController : ControllerBase
    {
        private readonly netFoodDbContext _context;

        public BundlesController(netFoodDbContext context)
        {
            _context = context;
        }

        // GET: api/Bundles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bundle>>> GetBundles()
        {
            return await _context.Bundles.ToListAsync();
        }

        // GET: api/Bundles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bundle>> GetBundle(int id)
        {
            var bundle = await _context.Bundles.FindAsync(id);

            if (bundle == null)
            {
                return NotFound();
            }

            return bundle;
        }

        // PUT: api/Bundles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBundle(int id, Bundle bundle)
        {
            if (id != bundle.Id)
            {
                return BadRequest();
            }

            _context.Entry(bundle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BundleExists(id))
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

        // POST: api/Bundles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Bundle>> PostBundle(Bundle bundle)
        {
            _context.Bundles.Add(bundle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBundle", new { id = bundle.Id }, bundle);
        }

        // DELETE: api/Bundles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bundle>> DeleteBundle(int id)
        {
            var bundle = await _context.Bundles.FindAsync(id);
            if (bundle == null)
            {
                return NotFound();
            }

            _context.Bundles.Remove(bundle);
            await _context.SaveChangesAsync();

            return bundle;
        }

        private bool BundleExists(int id)
        {
            return _context.Bundles.Any(e => e.Id == id);
        }
    }
}
