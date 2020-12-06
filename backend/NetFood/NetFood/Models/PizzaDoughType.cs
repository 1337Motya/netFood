using System;
using System.Collections.Generic;

namespace NetFood.Models
{
    public partial class PizzaDoughType
    {
        public int Id { get; set; }
        public int? Pizza { get; set; }
        public string DoughType { get; set; }

        public virtual Pizza PizzaNavigation { get; set; }
    }
}
