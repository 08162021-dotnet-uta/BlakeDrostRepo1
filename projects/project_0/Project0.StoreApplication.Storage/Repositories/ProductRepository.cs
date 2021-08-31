using System.Collections.Generic;
using Project0.StoreApplication.Domain.Interfaces;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Adapters;

namespace Project0.StoreApplication.Storage.Repositories
{
  public class ProductRepository : IRepository<Product>
  {
    private const string _path = @"/home/blake/revature/blake_code/data/products.xml";

    private static readonly FileAdapter _fileAdapter = new FileAdapter();
    //private static readonly DataAdapter _dataAdapter = new DataAdapter();

    public ProductRepository()
    {
      if (_fileAdapter.ReadFromFile<Product>(_path) == null)
      {
        _fileAdapter.WriteToFile<Product>(_path, new List<Product>(){
        new Product(){ ProductName = "Shoe", ProductPrice = 20.00, ProductQuantity = 50},
        new Product(){ ProductName = "Shirt", ProductPrice = 50.00, ProductQuantity = 50},
        new Product(){ ProductName = "Hat", ProductPrice = 30.00, ProductQuantity = 50}});
      }
    }

    public bool Insert(List<Product> entry)
    {
      _fileAdapter.WriteToFile<Product>(_path, entry);

      return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Product Update()
    {
      throw new System.NotImplementedException();
    }

    /// <summary>
    /// Will read from products.xml
    /// Returns a list of Products
    /// </summary>
    /// <returns></returns>
    public List<Product> Select()
    {
      return _fileAdapter.ReadFromFile<Product>(_path);
    }

    /*public List<Product> SelectDB()
    {
      return _dataAdapter.GetProducts();
    }*/

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool Delete()
    {
      throw new System.NotImplementedException();
    }
  }
}