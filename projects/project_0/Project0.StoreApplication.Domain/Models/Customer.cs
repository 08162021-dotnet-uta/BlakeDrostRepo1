using System.Collections.Generic;

namespace Project0.StoreApplication.Domain.Models
{
  public class Customer
  {
    public int CustomerID { get; set; }
    public string CustomerName { get; set; }
    public bool Active { get; set; }

    public List<Order> Orders = new List<Order>();

    public override string ToString()
    {
      return CustomerName;
    }

    public void AddOrder(Order o)
    {
      Orders.Add(o);
    }
  }
}