using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
  public class Topping : IPizzaParts
  {
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Topping(string n, decimal p)
    {
      Name = n;
      Price = p;
    }
  }
}