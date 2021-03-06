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
    public class OrdersController : ControllerBase
    {
        private readonly netFoodDbContext _context;

        public OrdersController(netFoodDbContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        public ActionResult<IEnumerable<OrderInfo>> GetOrders()
        {
            var orders = _context.Orders.Include(i => i.OrderItems).ToList();
            List<OrderInfo> orderInfos = new List<OrderInfo>();
            foreach (var order in orders)
            {
                List<IProduct> products = new List<IProduct>();
                var orderItems = order.OrderItems;
                foreach (var item in orderItems)
                {
                    switch (item.CategoryId)
                    {
                        case 1:
                            PizzaOrder pizza = _context.PizzaOrders.Include(i => i.Pizza)
                                .Include(i => i.PizzaDoughType)
                                .Include(i => i.PizzaSize)
                                .Where(i => i.Id == item.ProductId).First();
                            products.Add(new PizzaDto(pizza, item.Amount));
                            break;
                        case 2:
                            Drink drink = _context.Drinks.Where(i => i.Id == item.ProductId).First();
                            products.Add(new DrinkDto(drink, item.Amount));
                            break;
                        case 3:
                            Snack snack = _context.Snacks.Where(i => i.Id == item.ProductId).First();
                            products.Add(new SnackDto(snack, item.Amount));
                            break;
                        case 4:
                            Dessert dessert = _context.Desserts.Where(i => i.Id == item.ProductId).First();
                            products.Add(new DessertDto(dessert, item.Amount));
                            break;
                        case 5:
                            products.Add(_context.Bundles.Where(i => i.Id == item.ProductId).First());
                            break;
                    }
                }
                order.OrderItems = null;
                orderInfos.Add(
                        new OrderInfo()
                        {
                            order = order,
                            products = products
                        }
                        );
            }
            return orderInfos.OrderByDescending(i => i.order.Id).ToList();
            //return await _context.Orders.Include(o => o.OrderItems).ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Orders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return order;
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
