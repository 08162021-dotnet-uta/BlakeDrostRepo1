using System.Collections.Generic;
using Project0.StoreApplication.Domain.Interfaces;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Adapters;

namespace Project0.StoreApplication.Storage.Repositories
{
  public class OrderRepository : IRepository<Order>
  {

    private const string _path = @"/home/blake/revature/blake_code/data/orders.xml";

    private static readonly FileAdapter _fileAdapter = new FileAdapter();
    //public static List<Order> Orders { get; set; }
    public static List<Order> Orders = new List<Order>();

    public OrderRepository()
    {
      if (_fileAdapter.ReadFromFile<Order>(_path) == null)
      {
        _fileAdapter.WriteToFile<Order>(_path, new List<Order>());
      }
      else
      {
        Orders = _fileAdapter.ReadFromFile<Order>(_path);
      }
    }

    public void AddOrder(Store s, Product p)
    {
      Orders.Add(new Order() { Store = s, Product = p });
      _fileAdapter.WriteToFile<Order>(_path, Orders);
      Orders = _fileAdapter.ReadFromFile<Order>(_path);
    }

    public List<Order> GetOrders()
    {
      return Orders;
    }
    public bool Insert(List<Order> entry)
    {
      _fileAdapter.WriteToFile<Order>(_path, entry);

      return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Order Update()
    {
      throw new System.NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List<Order> Select()
    {
      return _fileAdapter.ReadFromFile<Order>(_path);
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