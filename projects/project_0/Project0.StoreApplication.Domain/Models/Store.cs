using System.Collections.Generic;

namespace Project0.StoreApplication.Domain.Models
{
  public class Store
  {
    public string Location { get; set; }
    private List<Order> Orders = new List<Order>();
    //public List<Order> Orders {get; set new List<Order>();}

    public override string ToString()
    {
      return Location;
    }

    public void AddOrder(Order o)//Needs to be implemented throughout the rest of the code
    {
      Orders.Add(o);
    }
    //Return orders not implemented
  }
}