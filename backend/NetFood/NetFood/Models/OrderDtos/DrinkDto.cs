using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetFood.Models
{
    public class DrinkDto : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public double? Volume { get; set; }
        public int? Amount { get; set; }
        public int? CategoryId { get; set; }

        public DrinkDto(Drink drink, int? amount)
        {
            Id = drink.Id;
            Name = drink.Name;
            ImageUrl = drink.ImageUrl;
            Volume = drink.Volume;
            Amount = amount;
            CategoryId = drink.CategoryId;
        }
    }
}
