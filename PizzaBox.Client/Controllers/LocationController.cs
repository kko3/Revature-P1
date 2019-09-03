using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Data;
using PizzaBox.Domain.Models;

namespace  PizzaBox.Client.Controllers
{
    public class MapOfStores
    {
      public User Customer { get; set; }
      public List<Location> LocationsInArea { get; set; }
    }
    public class LocationController : Controller
    {
        private PizzaBoxDBContext _db = new PizzaBoxDBContext();
        public IActionResult ViewLocations(int uId)
        {;
          MapOfStores ms = new MapOfStores();
          ms.Customer = _db.Users.Find(uId);
          ms.LocationsInArea = _db.Locations.ToList();
          return View(ms);
        }
        public IActionResult ChangeLocations(int lId,int uId)
        {
          User u = _db.Users.Find(uId);
          Location newselectedLocation = _db.Locations.Find(lId);
          u.SelectedLocation = newselectedLocation;

          return View("~/Views/User/ViewAccount.cshtml",u);
        }
    }
}