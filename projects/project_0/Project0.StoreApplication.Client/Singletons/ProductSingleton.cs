using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Repositories;

namespace Project0.StoreApplication.Client.Singletons
{
  public class ProductSingleton
  {
    private static ProductSingleton _productSingleton;
    private static readonly ProductRepository _productRepository = new ProductRepository();
    public List<Product> Products { get; }
    public static ProductSingleton Instance
    {
      get
      {
        if (_productSingleton == null)
        {
          _productSingleton = new ProductSingleton();
        }
        return _productSingleton;
      }
    }

    /// <summary>
    /// Populates the List of Products property for the Singleton
    /// </summary>
    private ProductSingleton()
    {
      Products = _productRepository.Select();
    }
  }
}