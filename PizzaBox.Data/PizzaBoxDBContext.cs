using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Data
{
  public class PizzaBoxDBContext : DbContext
  {
    public DbSet<Crust> Crusts { get; set; }
    public DbSet<Topping> Toppings { get; set; }
    public DbSet<Size> Sizes { get; set; }

    public DbSet<Pizza> Pizzas {get; set; }
    public DbSet<User> Users { get; set; }

    public DbSet<Location> Locations { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer("Server=tcp:keilpizza.database.windows.net,1433;Initial Catalog=P1PizzaBoxDB;Persist Security Info=False;User ID=sqladmin;Password=Password12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Crust>().HasKey(c=>c.Id);
      builder.Entity<Crust>().HasIndex(c=> c.Name).IsUnique();

      builder.Entity<Topping>().HasKey(t=>t.Id);
      builder.Entity<Topping>().HasIndex(t=>t.Name).IsUnique();

      builder.Entity<Size>().HasKey(s=>s.Id);
      builder.Entity<Size>().HasIndex(s=>s.Name).IsUnique();

      builder.Entity<Pizza>().HasKey(p=>p.Id);

      builder.Entity<User>().HasKey(u=>u.Id);
      builder.Entity<User>().HasIndex(u=>u.UserName).IsUnique();

      builder.Entity<Location>().HasKey(l=>l.Id);

      builder.Entity<Order>().HasKey(o=>o.Id);
      builder.Entity<Order>().HasIndex(o=>o.OrderNumber).IsUnique();
    }
  }
}