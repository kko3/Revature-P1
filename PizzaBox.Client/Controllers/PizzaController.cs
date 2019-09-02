using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain.Models;

namespace  Pizzabox.Client.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult CreatePizza(Crust c,Size s, Topping t)
        {
           
           return View();
        }
    }
}