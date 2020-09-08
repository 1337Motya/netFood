using BLL.net_food.Interfaces;
using BLL.net_food.Services;
using Ninject.Modules;

namespace net_food.Util
{
    public class DrinkModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDrinkService>().To<DrinkService>();
        }
    }
}