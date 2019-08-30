using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class User
  {
    public List<Order> OrderHistory { get; set; }
    public string AccountName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public Location SelectedLocation { get; set; }


    public User UserLogin(){
      User u = new User();

      string typedusername = "";
      string typedpassword = "";

      while( u.UserName != typedusername || u.Password != typedpassword)
      {
        typedusername = "";
        typedpassword = "";

        Console.WriteLine("What is your username?");
        typedusername = Console.ReadLine();

        Console.WriteLine("password?");
        typedpassword = Console.ReadLine();

        if(u.UserName != typedusername || u.Password != typedpassword)
        {
          Console.WriteLine();
          Console.WriteLine("Try Again");
        }
      }

      u.AccountName = "Test";

      return u;
    }
    public User UserLogOut(){
      User u = new User();

      return u;
    }

    public User CreateLogin()
    {
      User u = new User();
      string typedusername = "";
      string typedpassword1 = "";
      string typedpassword2 = "";

      Console.WriteLine("What is your username?");
      typedusername = Console.ReadLine();
      do
      {
        Console.WriteLine("Password?");
        typedpassword1 = Console.ReadLine();
        Console.WriteLine("Reenter your Password.");
        typedpassword2 = Console.ReadLine();
      }while(typedpassword1 != typedpassword2);

      u.UserName = typedusername;
      u.AccountName = typedusername;
      u.Password = typedpassword1;


      return u;
    }
    public Location SelectFromLocations(List<Location> lol)
    {
      Location LocationChoice = new Location("n");
      int choice = -1;
      Console.WriteLine("What Location did you want to order from?");
      do{
        for(int i = 0; i < lol.Count; i++){
          Console.WriteLine($"{i+1}. {lol[i].LocationName}");
        }
        choice = Convert.ToInt32(Console.ReadLine())-1;
      }while(choice < 0 || choice > lol.Count-1);

      LocationChoice = lol[choice];

      return LocationChoice;
    }

    public Location PlaceOrder(List<Location> lol,User u)
    {
      
      Order o = new Order();   

      u.SelectedLocation = SelectFromLocations(lol);

      Console.WriteLine($"Ordering from Location {u.SelectedLocation}");
      o.Pizzas = OrderPizza(o);
      o.Cost = o.CalculateCost();
      //o.ViewPizzas();
      //Console.WriteLine(o.Cost);

      u.SelectedLocation.CurrentOrders.Add(o);
      u.SelectedLocation.Users.Add(u);
      
      u.OrderHistory.Add(o);

      return u.SelectedLocation;
    }
    public List<Pizza> OrderPizza(Order o)
    {
      int choice = -1;
      bool orderdone = false;
      decimal pizzaprice = -1m;
      decimal toppingCost = -1m;
      Size s;
      Crust c;
      //Pizza p;
      List<Topping> toppinglist = new List<Topping>();
      List<Pizza> PizzaOrdered = new List<Pizza>();
      
      while(!orderdone)
      {
        choice = -1;

        s = ChooseSize();
        c = ChooseCrust();
        toppinglist = ChooseToppings();
        toppingCost = 0m;
        foreach(var t in toppinglist)
        {
          toppingCost += t.Price;
        }
        pizzaprice = s.Price + c.Price + toppingCost;        

        //p = ;
        PizzaOrdered.Add(new Pizza(c,s,toppinglist,pizzaprice));


        Console.WriteLine("Are you done Ordering?");
        Console.WriteLine("1.Yes or 2.No (1 or 2)?");
        choice = Convert.ToInt32(Console.ReadLine());
        
        if(choice == 1){
          orderdone = true;
        }
        else if(o.Pizzas.Count + 1 == o.PizzaLimit)
        {
          orderdone = true;
        }
        else if(o.Cost + 10 >= o.CostLimit)
        {
          orderdone = true;
        }
      }

      return PizzaOrdered;
    }

    public Size ChooseSize()
    {
        int ordersize = -1;

        do
        {
          Console.WriteLine("What size pizza would you like?");
          Console.WriteLine("1.Small");
          Console.WriteLine("2.Medium");
          Console.WriteLine("3.Large");
          ordersize = Convert.ToInt32(Console.ReadLine());
        }while(ordersize < 1 || ordersize > 3);

        if(ordersize == 1)
        {
          return new Size("Small",5.00m);
        }
        else if(ordersize == 2)
        {
          return new Size("Medium",7.50m);
        }
        else
        {
          return new Size("Large",10.00m);
        }
    }

    public Crust ChooseCrust()
    {
        int cruststyle = -1;

        do
        {
          Console.WriteLine("What style of crust would you like?");
          Console.WriteLine("1.Thin");
          Console.WriteLine("2.Regular");
          Console.WriteLine("3.Garlic Butter");
          cruststyle = Convert.ToInt32(Console.ReadLine());
        }while(cruststyle < 1 || cruststyle > 3);

        if(cruststyle == 1)
        {
          return new Crust("Thin",2.50m);
        }
        else if(cruststyle == 2)
        {
          return new Crust("Regular",5.00m);
        }
        else
        {
          return new Crust("Garlic Butter",7.50m);
        }
    }

    public List<Topping> ChooseToppings()
    {
      List<Topping> toppinglist = new List<Topping>();
      int choice = -1;
      int toppingchoice = -1;
      int toppingcount = 0;

        toppinglist.Clear();
        do
        {
          bool toppingincluded = false;

          Console.WriteLine("What Toppings would you like?");
          Console.WriteLine("1.Cheese");
          Console.WriteLine("2.Sauce");
          Console.WriteLine("3.Pepperoni");
          Console.WriteLine("4.Mushrooms");
          Console.WriteLine("5.Onions");
          toppingchoice = Convert.ToInt32(Console.ReadLine());

          if(toppingchoice >= 1 && toppingchoice <= 5)
          {
            Topping t;
            if(toppingchoice == 1)
            {
              t = new Topping("Cheese",.50m);
            }
            else if(toppingchoice == 2)
            {
              t = new Topping("Sauce",.50m);
            }
            else if(toppingchoice == 3)
            {
              t = new Topping("Pepperoni",.50m);
            }
            else if(toppingchoice == 4)
            {
              t = new Topping("Mushrooms",.50m);
            }
            else
            {
              t = new Topping("Onions",.50m);
            }
            foreach (var top in toppinglist)
            {
                if(t.Name == top.Name)
                {
                 toppingincluded = true;
                 Console.WriteLine("Thats already on the Pizza");
                }
            }

            if(!toppingincluded){
              toppinglist.Add(t);
              toppingcount += 1;
            }

            if(toppingcount >= 2 && toppingcount <= 4)
            {
              Console.WriteLine("Anymore Toppings?");
              Console.WriteLine("1.Yes or 2.No");
              choice = Convert.ToInt32(Console.ReadLine());
              
              if(choice == 2)
              {
                break;
              }
            }
          }
        }while(toppingchoice < 5);

        return toppinglist;
    }

    public User()
    {
      AccountName = "None";
      UserName = "username";
      Password = "password";
      OrderHistory = new List<Order>();
    }
  }
}