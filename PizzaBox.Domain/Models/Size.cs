using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
  public class Size : IPizzaParts
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Size(){}
    public Size(string n,decimal p)
    {
      Name = n;
      Price = p;
    }
  }
}