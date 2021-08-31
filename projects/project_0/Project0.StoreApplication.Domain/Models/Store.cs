using System.Collections.Generic;

namespace Project0.StoreApplication.Domain.Models
{
  public class Store
  {
    public int StoreID { get; set; }
    public string StoreLocation { get; set; }

    public override string ToString()
    {
      return StoreLocation;
    }
  }
}