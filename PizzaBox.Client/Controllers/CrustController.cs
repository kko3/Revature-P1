using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Controllers
{
    public class CrustController : Controller
    {
        public IActionResult Create(Crust c)
        {

          return View();
        }
    }
}