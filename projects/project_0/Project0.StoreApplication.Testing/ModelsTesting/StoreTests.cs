using Xunit;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Testing.ModelsTesting
{
  public class StoreTests
  {
    [Fact]
    public void Test_CreateStore()
    {
      var sut = new Store();
    }
    [Fact]
    public void Test_StoreToString()
    {
      var sut = new Store();
      sut.ToString();
    }
  }
}