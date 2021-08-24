namespace Project0.StoreApplication.Domain.Models
{
  public class Order
  {
    public Customer Customer
    {
      get;
      set;
    }
    public Product Product
    {
      get;
      set;
    }
    public Store Store
    {
      get;
      set;
    }
  }
}