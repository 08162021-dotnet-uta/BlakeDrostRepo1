using Xunit;
using Project0.StoreApplication.Storage.Repositories;

namespace Project0.StoreApplication.Testing.RepositoryTesting
{
  public class ProductRepositoryTests
  {
    [Fact]
    public void Test_CreateProductRepository()
    {
      var sut = new ProductRepository();
    }
    [Fact]
    public void Test_ProductRepositorySelect()
    {
      var sut = new ProductRepository();
      var actual = sut.Select();
      Assert.NotNull(actual);
    }
  }
}