using System;
using System.Collections.Generic;

namespace NetFood.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public bool СashPayment { get; set; }
        public decimal? OrderSum { get; set; }
        public DateTime? OrderDate { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
