using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
  public class Size : IPizzaParts
  {
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Size(string n,decimal p)
    {
      Name = n;
      Price = p;
    }
  }
}