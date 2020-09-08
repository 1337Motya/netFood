using System.Collections.Generic;

namespace DAL.net_food.Interfaces
{
    public  interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        T Get(int id);
        void Create(T item);
        void Delete(T item);
        void Update(T item);
    }
}
