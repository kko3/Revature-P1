using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Data;
using PizzaBox.Domain.Models;

namespace  Pizzabox.Client.Controllers
{
    public class PizzaController : Controller
    {
        private PizzaBoxDBContext _db = new PizzaBoxDBContext();

        [HttpGet]
        public IActionResult CreatePizza()
        {
          return View();
        }
        [HttpPost]
        public IActionResult CreatePizza(int crust,int size, List<int> topping)
        {
          Crust c = _db.Crusts.Find(crust);
          Size s = _db.Sizes.Find(size);

          decimal cost = 0;
          decimal toppingcost = 0;

          List<Topping> t = new List<Topping>();
          foreach (var item in topping)
          {
              t.Add(_db.Toppings.Find(item));
          }
          foreach (var item in t)
          {
              toppingcost += item.Price;
          }
         
         cost = c.Price + s.Price + toppingcost;
         Pizza p = new Pizza(c,s,t,cost);

          return View("ViewPizza",p);
        }

        public IActionResult ViewPizza(Pizza p)
        {

          return View(p);
        }
    }
}