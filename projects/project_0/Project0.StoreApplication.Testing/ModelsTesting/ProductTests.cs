using Xunit;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Testing.ModelsTesting
{
  public class ProductTests
  {
    [Fact]
    public void Test_CreateProduct()
    {
      var sut = new Product();
    }
    [Fact]
    public void Test_ProductToString()
    {
      var sut = new Product();
      sut.ToString();
    }
  }
}