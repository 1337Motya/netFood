using DAL.net_food.Entities;
using System.Data.Entity;


namespace DAL.net_food
{
    class NetFoodContext : DbContext
    {
        public NetFoodContext(string connectionString) : base(connectionString)
        {

        }

        public DbSet<Drink> Drinks { get; set; }
    }
}
