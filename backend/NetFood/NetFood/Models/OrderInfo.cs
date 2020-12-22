using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetFood.Models
{
    public class OrderInfo
    {
        public Order order;
        public IEnumerable<IProduct> products;
    }
}
