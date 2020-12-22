using System;
using System.Collections.Generic;

namespace NetFood.Models
{
    public partial class PizzaDoughType
    {
        public PizzaDoughType()
        {
            //PizzaOrders = new HashSet<PizzaOrder>();
        }

        public int Id { get; set; }
        public int? Pizza { get; set; }
        public string DoughType { get; set; }

        public virtual Pizza PizzaNavigation { get; set; }
        //public virtual ICollection<PizzaOrder> PizzaOrders { get; set; }
    }
}
