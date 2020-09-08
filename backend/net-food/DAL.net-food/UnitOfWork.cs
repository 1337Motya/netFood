using DAL.net_food.Entities;
using DAL.net_food.Interfaces;
using DAL.net_food.Repositories;
using System;
using System.Data;

namespace DAL.net_food
{
    public class UnitOfWork : IUnitOfWork
    {
        private NetFoodContext context;

        private IRepository<Drink> drinkRepository;

        private bool disposed = false;

        public UnitOfWork(string connectionstring)
        {
            context = new NetFoodContext(connectionstring);
        }

        public void save()
        {
            context.SaveChanges();
        }

        public IRepository<Drink> Drinks
        {
            get
            {
                if (drinkRepository == null)
                    drinkRepository = new DrinkRepository(context);
                return drinkRepository;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
    }
}
