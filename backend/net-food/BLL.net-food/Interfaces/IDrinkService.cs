using BLL.net_food.Services;
using DAL.net_food.Entities;
using System.Collections.Generic;

namespace BLL.net_food.Interfaces
{
    public interface IDrinkService
    {
        IEnumerable<Drink> Get();
        Drink Get(int id);
        void Order(Drink orderDto);
        void Update(Drink drink);
        void Dispose();
    }
}
