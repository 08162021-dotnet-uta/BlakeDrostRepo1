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

    public ProductRepository()
    {
      if (_fileAdapter.ReadFromFile<Product>(_path) == null)
      {
        _fileAdapter.WriteToFile<Product>(_path, new List<Product>(){
        new Product(){ Name = "Shoe"},
        new Product(){ Name = "Shirt"},
        new Product(){ Name = "Hat"}});
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
    /// 
    /// </summary>
    /// <returns></returns>
    public List<Product> Select()
    {
      return _fileAdapter.ReadFromFile<Product>(_path);
    }

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