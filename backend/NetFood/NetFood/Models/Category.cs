using System;
using System.Collections.Generic;

namespace NetFood.Models
{
    public partial class Category
    {
        public Category()
        {
            Bundles = new HashSet<Bundle>();
            Desserts = new HashSet<Dessert>();
            Drinks = new HashSet<Drink>();
            OrderItems = new HashSet<OrderItem>();
            Pizzas = new HashSet<Pizza>();
            Snacks = new HashSet<Snack>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Bundle> Bundles { get; set; }
        public virtual ICollection<Dessert> Desserts { get; set; }
        public virtual ICollection<Drink> Drinks { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Pizza> Pizzas { get; set; }
        public virtual ICollection<Snack> Snacks { get; set; }
    }
}
