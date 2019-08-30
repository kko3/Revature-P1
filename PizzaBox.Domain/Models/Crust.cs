using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
  public class Crust : IPizzaParts
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Crust(string n, decimal p)
    {
      Name = n;
      Price = p;
    }
  }

}