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
        public IActionResult FrontPage(string username,string password){

          User u = new User();
          foreach (var item in _db.Users)
          {
              if(username == item.UserName)
              {
                if(password == item.Password)
                {
                  u = item;
                  return View("ViewAccount",u);
                }
              }
          }

          return View();
        }

        [HttpGet]
        public IActionResult CreateAccount()
        {
          return View();
        }
        [HttpPost]
        public IActionResult CreateAccount(string username,string password1,string password2){
          foreach (var item in _db.Users)
          {
             if(username == item.UserName)
             {
               return View();
             } 
          }
          if(password1 != password2)
          {
            return View();
          }

          User u = new User();
          u.UserName = username;
          u.Password = password1;
          
          _db.Users.Add(u);
          _db.SaveChanges();

          return RedirectToAction("FrontPage");
        }
        public IActionResult ViewAccount()
        {
          return View();
          //return RedirectToAction("OrderPizza","Pizza");
        }
    }
}