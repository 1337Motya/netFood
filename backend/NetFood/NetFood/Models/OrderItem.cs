using System;
using System.Collections.Generic;

namespace NetFood.Models
{
    public partial class OrderItem
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? CategoryId { get; set; }
        public int? ProductId { get; set; }
        public int? Amount { get; set; }

        public virtual Category Category { get; set; }
        public virtual Order Order { get; set; }
    }
}
