using Xunit;
using Project0.StoreApplication.Client.Singletons;

namespace Project0.StoreApplication.Testing.SingletonsTesting
{
  public class ProductSingletonTests
  {
    [Fact]
    public void Test_CreateProductSingleton()
    {
      var sut = ProductSingleton.Instance;
    }
  }
}