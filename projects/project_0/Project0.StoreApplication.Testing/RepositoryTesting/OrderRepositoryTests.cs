using Xunit;
using Project0.StoreApplication.Storage.Repositories;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Testing.RepositoryTesting
{
  public class OrderRepositoryTests
  {
    [Fact]
    public void Test_CreateOrderRepository()
    {
      var sut = new OrderRepository();
    }
    [Fact]
    public void Test_OrderRepositorySelect()
    {
      var sut = new OrderRepository();
      var actual = sut.Select();
      Assert.NotNull(actual);
    }
  }
}