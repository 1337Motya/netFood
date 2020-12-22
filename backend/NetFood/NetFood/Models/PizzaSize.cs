using System;
using System.Collections.Generic;

namespace NetFood.Models
{
    public partial class PizzaSize
    {
        public PizzaSize()
        {
            //PizzaOrders = new HashSet<PizzaOrder>();
        }

        public int Id { get; set; }
        public int? Pizza { get; set; }
        public int? Size { get; set; }
        public decimal? Price { get; set; }

        public virtual Pizza PizzaNavigation { get; set; }
        //public virtual ICollection<PizzaOrder> PizzaOrders { get; set; }
    }
}
