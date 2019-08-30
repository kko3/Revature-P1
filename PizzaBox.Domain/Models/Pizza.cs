using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class Pizza
  {
    public Crust PizzaCrust { get; set; }
    public Size PizzaSize { get; set; }

    public List<Topping> PizzaToppings { get; set; }

    public decimal Cost { get; set; }

    public Pizza(Crust c,Size s,List<Topping> t,decimal co)
    {
      PizzaCrust = c;
      PizzaSize = s;
      PizzaToppings = t;
      Cost = co;
    }
  }
}