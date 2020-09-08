using System;
using System.Collections.Generic;
using BLL.net_food.Interfaces;
using DAL.net_food.Entities;
using DAL.net_food.Interfaces;

namespace BLL.net_food.Services
{
    public class DrinkService : IDrinkService
    {
        IUnitOfWork Database { get; set; }

        public DrinkService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Drink> Get()
        {
            return Database.Drinks.Get();
        }

        public Drink Get(int id)
        {
            return Database.Drinks.Get(id);
        }

        public void Order(Drink orderDto)
        {
            throw new NotImplementedException();
        }

        public void Update(Drink drink)
        {
            Database.Drinks.Update(drink);
        }
    }
}
