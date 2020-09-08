using System.Web.Mvc;
using BLL.net_food.Interfaces;
using BLL.net_food.Services;
using DAL.net_food.Entities;

namespace net_food.Controllers
{
    public class HomeController : Controller
    {
        IDrinkService drinks;

        public HomeController(IDrinkService service)
        {
            drinks = service;
        }

        public ActionResult Edit(int id)
        {
            var drink = drinks.Get(id);

            return View(drink);
        }

        [HttpPost]
        public ActionResult Edit(Drink drink)
        {

            drinks.Update(drink);

            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            return View(drinks.Get());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}