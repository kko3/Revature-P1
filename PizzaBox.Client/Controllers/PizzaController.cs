using Microsoft.AspNetCore.Mvc;

namespace PizzaBox.Client.Controllers
{
  public class PizzaController : Controller
  {
      public IActionResult LoginPage()
      {
        return View();
      }

  }
}