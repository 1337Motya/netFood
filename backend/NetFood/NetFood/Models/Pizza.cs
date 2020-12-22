using System;
using System.Collections.Generic;

namespace NetFood.Models
{
    public partial class Pizza : IProduct
    {
        public Pizza()
        {
            PizzaDoughTypes = new HashSet<PizzaDoughType>();
            //PizzaOrders = new HashSet<PizzaOrder>();
            PizzaSizes = new HashSet<PizzaSize>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<PizzaDoughType> PizzaDoughTypes { get; set; }
        //public virtual ICollection<PizzaOrder> PizzaOrders { get; set; }
        public virtual ICollection<PizzaSize> PizzaSizes { get; set; }
    }
}
