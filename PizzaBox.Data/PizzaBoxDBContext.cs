using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Data
{
  public class PizzaBoxDBContext : DbContext
  {
    public DbSet<Crust> Crusts { get; set; }
    public DbSet<User> Users {get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer("Server=tcp:keilpizza.database.windows.net,1433;Initial Catalog=P1PizzaBoxDB;Persist Security Info=False;User ID=sqladmin;Password=Password12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Crust>().HasKey(c=>c.Id);
      builder.Entity<Crust>().HasIndex(c=> c.Name).IsUnique();

      builder.Entity<User>().HasKey(u=>u.Id);
      builder.Entity<User>().HasIndex(u=>u.UserName).IsUnique();
    }
  }
}