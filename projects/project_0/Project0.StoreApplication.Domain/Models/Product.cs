namespace Project0.StoreApplication.Domain.Models
{
  public class Product
  {
    public string Name { set; get; }

    public override string ToString()
    {
      return Name;
    }
  }
}