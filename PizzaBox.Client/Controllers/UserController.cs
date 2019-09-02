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
          return RedirectToAction("OrderPizza","Pizza");
        }
    }
}