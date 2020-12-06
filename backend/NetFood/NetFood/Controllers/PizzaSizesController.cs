using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetFood.Models;

namespace NetFood.Controllers
{
    public class PizzaSizesController : Controller
    {
        private readonly netFoodDbContext _context;

        public PizzaSizesController(netFoodDbContext context)
        {
            _context = context;
        }

        // GET: PizzaSizes
        public async Task<IActionResult> Index()
        {
            var netFoodDbContext = _context.PizzaSizes.Include(p => p.PizzaNavigation);
            return View(await netFoodDbContext.ToListAsync());
        }

        // GET: PizzaSizes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizzaSize = await _context.PizzaSizes
                .Include(p => p.PizzaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pizzaSize == null)
            {
                return NotFound();
            }

            return View(pizzaSize);
        }

        // GET: PizzaSizes/Create
        public IActionResult Create()
        {
            ViewData["Pizza"] = new SelectList(_context.Pizzas, "Id", "Id");
            return View();
        }

        // POST: PizzaSizes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Pizza,Size,Price")] PizzaSize pizzaSize)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pizzaSize);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Pizza"] = new SelectList(_context.Pizzas, "Id", "Id", pizzaSize.Pizza);
            return View(pizzaSize);
        }

        // GET: PizzaSizes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizzaSize = await _context.PizzaSizes.FindAsync(id);
            if (pizzaSize == null)
            {
                return NotFound();
            }
            ViewData["Pizza"] = new SelectList(_context.Pizzas, "Id", "Id", pizzaSize.Pizza);
            return View(pizzaSize);
        }

        // POST: PizzaSizes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Pizza,Size,Price")] PizzaSize pizzaSize)
        {
            if (id != pizzaSize.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pizzaSize);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PizzaSizeExists(pizzaSize.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Pizza"] = new SelectList(_context.Pizzas, "Id", "Id", pizzaSize.Pizza);
            return View(pizzaSize);
        }

        // GET: PizzaSizes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizzaSize = await _context.PizzaSizes
                .Include(p => p.PizzaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pizzaSize == null)
            {
                return NotFound();
            }

            return View(pizzaSize);
        }

        // POST: PizzaSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pizzaSize = await _context.PizzaSizes.FindAsync(id);
            _context.PizzaSizes.Remove(pizzaSize);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PizzaSizeExists(int id)
        {
            return _context.PizzaSizes.Any(e => e.Id == id);
        }
    }
}
