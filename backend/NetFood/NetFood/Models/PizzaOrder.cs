using System;
using System.Collections.Generic;

namespace NetFood.Models
{
    public partial class PizzaOrder : IProduct
    {
        public PizzaOrder()
        {
            Bundles = new HashSet<Bundle>();
        }

        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int PizzaSizeId { get; set; }
        public int PizzaDoughTypeId { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Pizza Pizza { get; set; }
        public virtual PizzaDoughType PizzaDoughType { get; set; }
        public virtual PizzaSize PizzaSize { get; set; }
        public virtual ICollection<Bundle> Bundles { get; set; }
    }
}
