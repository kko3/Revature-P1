namespace PizzaBox.Domain.Interfaces 
{
    public interface IPizzaParts
    {
        public int Id { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
    }
}