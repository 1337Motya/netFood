using System;
using System.Collections.Generic;

namespace NetFood.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            Bundles = new HashSet<Bundle>();
            PizzaDoughTypes = new HashSet<PizzaDoughType>();
            PizzaSizes = new HashSet<PizzaSize>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Bundle> Bundles { get; set; }
        public virtual ICollection<PizzaDoughType> PizzaDoughTypes { get; set; }
        public virtual ICollection<PizzaSize> PizzaSizes { get; set; }
    }
}
