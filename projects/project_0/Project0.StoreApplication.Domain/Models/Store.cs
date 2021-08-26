using System.Collections.Generic;

namespace Project0.StoreApplication.Domain.Models
{
  public class Store
  {
    public string Location { get; set; }
    public List<Order> Orders;

    public override string ToString()
    {
      return Location;
    }

    //Return orders not implemented
  }
}