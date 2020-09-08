using System;
using DAL.net_food.Entities;

namespace DAL.net_food.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Drink> Drinks { get; }
        void save();
    }
}
