using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetFood.Models
{
    public class DessertDto : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int? Amount { get; set; }
        public int? CategoryId { get; set; }

        public DessertDto(Dessert dessert, int? amount)
        {
            Id = dessert.Id;
            Name = dessert.Name;
            ImageUrl = dessert.ImageUrl;
            Amount = amount;
            CategoryId = dessert.CategoryId;
        }
    }
}
