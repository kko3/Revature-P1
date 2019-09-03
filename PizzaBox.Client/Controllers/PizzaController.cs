using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Data;
using PizzaBox.Domain.Models;

namespace  PizzaBox.Client.Controllers
{
    public class PizzaController : Controller
    {
        private PizzaBoxDBContext _db = new PizzaBoxDBContext();

        private Order o = new Order();

        [HttpGet]
        public IActionResult CreatePizza()
        {
          return View();
        }
        [HttpPost]
        public IActionResult CreateCustomPizza(int crust,int size, List<int> topping,bool orderisdone)
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

        o.Pizzas.Add(p);
        _db.Orders.Add(o);
        _db.SaveChanges();
        
          if(orderisdone){
            return View("ViewPizza",o.Pizzas);
          }

          return RedirectToAction("OrderPizza");
        }

        public IActionResult ViewPizza(Pizza p)
        {

          return View(p);
        }
        public IActionResult OrderPizza(string pizza)
        {
          PizzaMenu pm = new PizzaMenu();

          pm.CrustsOnMenu = _db.Crusts.ToList();
          pm.SizesOnMenu = _db.Sizes.ToList();
          pm.ToppingsOnMenu = _db.Toppings.ToList();

          if(pizza == null){
            return View();
          }
          else if(pizza == "cheesepizza"){
            return View("CreateCheesePizza",pm);
          }

          return View();
        }
        public IActionResult CreateCustomPizzaMenu()
        {
           PizzaMenu pm = new PizzaMenu();

          pm.CrustsOnMenu = _db.Crusts.ToList();
          pm.SizesOnMenu = _db.Sizes.ToList();
          pm.ToppingsOnMenu = _db.Toppings.ToList();
          

          return View("~/Views/Pizza/CreateCustomPizza.cshtml",pm);
        }
    }
}