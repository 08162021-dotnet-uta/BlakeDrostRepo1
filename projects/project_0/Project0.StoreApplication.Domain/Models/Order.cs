namespace Project0.StoreApplication.Domain.Models
{
  public class Order
  {
    public int OrderID { get; set; }
    public int CustomerID { get; set; }
    public int StoreID { get; set; }
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
    public override string ToString()
    {
      return "Location: " + Store + ", Product: " + Product.ProductName + ", Price: " + Product.ProductPrice;
    }
  }
}