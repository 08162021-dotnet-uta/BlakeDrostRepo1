namespace Project0.StoreApplication.Domain.Models
{
  public class Product
  {
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public double ProductPrice { get; set; }
    public short ProductQuantity { get; set; }

    public override string ToString()
    {
      return "Name: " + ProductName + ", Price: $" + ProductPrice;
    }
  }
}