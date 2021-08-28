using Xunit;
using Project0.StoreApplication.Client.Singletons;

namespace Project0.StoreApplication.Testing.SingletonsTesting
{
  public class OrderSingletonTests
  {
    [Fact]
    public void Test_CreateOrderSingleton()
    {
      var sut = OrderSingleton.Instance;
    }
  }
}