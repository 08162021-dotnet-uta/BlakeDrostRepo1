using Xunit;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Testing.ModelsTesting
{
  public class OrderTests
  {
    [Fact]
    public void Test_CreateOrder()
    {
      var sut = new Order();
    }
    [Fact]
    public void Test_OrderToString()
    {
      var sut = new Order();
      sut.ToString();
    }
  }
}