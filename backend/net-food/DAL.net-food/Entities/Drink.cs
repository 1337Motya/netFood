using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.net_food.Entities
{
    public class Drink
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public short Calories { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public short Volume { get; set; }
    }
}
