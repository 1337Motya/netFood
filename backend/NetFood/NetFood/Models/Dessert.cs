using System;
using System.Collections.Generic;

namespace NetFood.Models
{
    public partial class Dessert : IProduct
    {
        public Dessert()
        {
            Bundles = new HashSet<Bundle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public decimal? Price { get; set; }
        public string ImageUrl { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Bundle> Bundles { get; set; }
    }
}
