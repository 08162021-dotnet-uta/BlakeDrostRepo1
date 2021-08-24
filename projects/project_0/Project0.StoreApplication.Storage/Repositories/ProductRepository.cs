
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Storage.Repositories
{
  public class ProductRepository
  {
    private const string _path = @"~/home/blake/revature/blake_code/data/products.xml";
    public List<Product> Products { get; set; }

    private ProductRepository()
    {
      Products = new List<Product>();
    }

    private static ProductRepository _productRepository;

    //creating a property
    public static ProductRepository Instance
    {
      get
      {
        if (_productRepository == null)
        {
          //create an instance of store repository
          _productRepository = new ProductRepository();
        }
        return _productRepository;
      }
    }
  }
}