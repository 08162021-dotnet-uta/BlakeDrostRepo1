using System.Collections.Generic;

namespace Project0.StoreApplication.Domain.Models
{
  public class Customer
  {
    public string Name { get; set; }

    public List<Order> Orders = new List<Order>();

    public override string ToString()
    {
      return Name;
    }

    public void AddOrder(Order o)
    {
      Orders.Add(o);
    }
  }
}