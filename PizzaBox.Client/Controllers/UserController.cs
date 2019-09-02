using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Data;
using PizzaBox.Domain.Models;

namespace Pizzabox.Client.Controllers
{

    public class UserController : Controller
    {
        private PizzaBoxDBContext _db = new PizzaBoxDBContext();
        
        [HttpGet]
        public IActionResult FrontPage()
        {
          return View();
        }

        [HttpPost]
        public IActionResult FrontPage(User u){

          return RedirectToAction("ViewAccount");
        }
        public IActionResult CreateAccount(){

          return View("~/Views/User/CreateAccount.cshtml");
        }
        public IActionResult ViewAccount()
        {
          PizzaMenu pm = new PizzaMenu();
          pm.CrustsOnMenu = _db.Crusts.ToList();
          pm.SizesOnMenu = _db.Sizes.ToList();
          pm.ToppingsOnMenu = _db.Toppings.ToList();

          return View("~/Views/Pizza/CreatePizza.cshtml",pm);
        }
    }
}