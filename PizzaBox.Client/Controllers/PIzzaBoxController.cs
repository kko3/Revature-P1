using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain.Models;

namespace Pizzabox.Client.Controllers
{
    public class PizzaBoxController : Controller
    {
        [HttpGet]
        public IActionResult FrontPage()
        {
          return View();
        }

        [HttpPost]
        public IActionResult FrontPage(User u){

          return RedirectToAction("ViewAccount");
        }
        public IActionResult ViewAccount()
        {
          return View("~/Views/User/ViewAccount.cshtml");
        }
    }
}