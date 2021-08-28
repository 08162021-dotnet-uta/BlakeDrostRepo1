namespace Project0.StoreApplication.Domain.Models
{
  public class Product
  {
    public string Name { set; get; }
    public double Price { set; get; }
    public short Quantity { set; get; }

    public override string ToString()
    {
      return "Name: " + Name + ", Price: $" + Price;
    }
  }
}