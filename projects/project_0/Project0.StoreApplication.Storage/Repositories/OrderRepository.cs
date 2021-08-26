using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Adapters;

namespace Project0.StoreApplication.Storage.Repositories
{
  public class OrderRepository
  {

    private const string _path = @"/home/blake/revature/blake_code/data/orders.xml";

    private static readonly FileAdapter _fileAdapter = new FileAdapter();
    public List<Order> Orders { get; set; }

    public OrderRepository()
    {
      if (_fileAdapter.ReadFromFile<Order>(_path) == null)
      {
        _fileAdapter.WriteToFile<Order>(_path, new List<Order>());
      }
    }
  }
}