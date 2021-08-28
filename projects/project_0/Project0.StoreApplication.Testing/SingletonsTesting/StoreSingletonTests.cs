using Xunit;
using Project0.StoreApplication.Client.Singletons;

namespace Project0.StoreApplication.Testing.SingletonsTesting
{
  public class StoreSingletonTests
  {
    [Fact]
    public void Test_CreateStoreSingleton()
    {
      var sut = StoreSingleton.Instance;
    }
  }
}