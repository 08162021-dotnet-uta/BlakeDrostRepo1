using Xunit;
using Project0.StoreApplication.Storage.Repositories;

namespace Project0.StoreApplication.Testing.RepositoryTesting
{
  public class StoreRepositoryTests
  {
    [Fact]
    public void Test_CreateStoreRepository()
    {
      var sut = new StoreRepository();
    }
    [Fact]
    public void Test_StoreRepositorySelect()
    {
      var sut = new StoreRepository();
      var actual = sut.Select();
      Assert.NotNull(actual);
    }
  }
}