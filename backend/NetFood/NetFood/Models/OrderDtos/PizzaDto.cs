using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetFood.Models
{
    public class PizzaDto : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string DoughType { get; set; }
        public int? Size { get; set; }
        public int? Amount { get; set; }
        public int CategoryId { get; set; }

        public PizzaDto(PizzaOrder pizzaOrder, int? amount)
        {
            Id = pizzaOrder.Id;
            Name = pizzaOrder.Pizza.Name;
            ImageUrl = pizzaOrder.Pizza.ImageUrl;
            DoughType = pizzaOrder.PizzaDoughType.DoughType;
            Size = pizzaOrder.PizzaSize.Size;
            Amount = amount;
            CategoryId = pizzaOrder.CategoryId;
        }
    }
}
