using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Storage.Adapters
{
  public class DataAdapter : DbContext
  {
    //private readonly DataAdapter _da = new DataAdapter();
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Store> Stores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer(@"server=(localdb)\MSSQLlocalDB;database=StoreApplicationDB;Trusted_Connection=True;");
    }

    public List<Product> GetProducts()
    {
      return Products.FromSqlRaw("SELECT ProductName, ProductPrice, ProductQuantity FROM Products").ToList();
    }

    public void setProduct(Product p)
    {
      Database.ExecuteSqlRaw("INSERT INTO Products Value ('" + p.ProductName + "'," + p.ProductPrice + "," + p.ProductQuantity + ")");
    }
  }
}