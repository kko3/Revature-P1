using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Data
{
  public class PizzaBoxDBContext : DbContext
  {
    public DbSet<Crust> Crusts { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<Size> Sizes  { get; set; }

    public DbSet<Topping> Toppings { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder){}
    protected override void OnModelCreating(ModelBuilder builder){}
  }
}