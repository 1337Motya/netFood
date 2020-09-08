using DAL.net_food.Entities;
using DAL.net_food.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.net_food.Repositories
{
    class DrinkRepository : IRepository<Drink>
    {
        private NetFoodContext db;

        public DrinkRepository(NetFoodContext context)
        {
            this.db = context;
        }

        public void Create(Drink drink)
        {
            db.Drinks.Add(drink);
        }

        public void Delete(Drink drink)
        {
            db.Drinks.Remove(drink);
        }

        public IEnumerable<Drink> Get()
        {
            return db.Drinks;
        }

        public Drink Get(int id)
        {
            return db.Drinks.Find(id);
        }

        public void Update(Drink drink)
        {
            db.Entry(drink).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
