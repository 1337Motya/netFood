using System;
using System.Collections.Generic;

namespace NetFood.Models
{
    public partial class Bundle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int? CategoryId { get; set; }
        public int? PizzaId { get; set; }
        public int? PizzaAmout { get; set; }
        public int? SnackId { get; set; }
        public int? SnackAmout { get; set; }
        public int? DrinkId { get; set; }
        public int? DrinkAmout { get; set; }
        public int? DessertId { get; set; }
        public int? DessertAmout { get; set; }
        public decimal? Price { get; set; }

        public virtual Category Category { get; set; }
        public virtual Dessert Dessert { get; set; }
        public virtual Drink Drink { get; set; }
        public virtual Pizza Pizza { get; set; }
        public virtual Snack Snack { get; set; }
    }
}
