using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Data;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Controllers
{
  public class OrderController : Controller
  {
    Order o;
    public IActionResult AddPizzaToOrder()
    {
      return View();
    }
  }
}