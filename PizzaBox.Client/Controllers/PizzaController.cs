using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain.Models;

namespace  Pizzabox.Client.Controllers
{
    public class PizzaController : Controller
    {
        [HttpGet]
        public IActionResult CreatePizza()
        {
          return View();
        }
        [HttpPost]
        public IActionResult CreatePizza(Crust c,Size s, List<Topping> t)
        {
          decimal toppingcost = 0;
          foreach (var item in t)
          {
              toppingcost += item.Price;
          }

          decimal cost = c.Price + s.Price+toppingcost;
           Pizza p = new Pizza(c,s,t,cost);

           //return RedirectToAction("ViewPizza",p);
           return View();
        }

        public IActionResult ViewPizza(Pizza p)
        {

          return View(p);
        }
    }
}