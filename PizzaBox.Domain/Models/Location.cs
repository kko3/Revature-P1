using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class Location
    {
      public List<Order> CurrentOrders { get; set; }
      public decimal Sales { get; set; }

      public string LocationName { get; set; }

      public List<User> Users { get; set; }

      //public Dictionary<string,int> Inventory { get; set; }

      public Location(string n)
      {
        LocationName = n;
        List<User> Users = new List<User>();
        List<Order> CurrentOrders = new List<Order>(); 
      }
    }
}

