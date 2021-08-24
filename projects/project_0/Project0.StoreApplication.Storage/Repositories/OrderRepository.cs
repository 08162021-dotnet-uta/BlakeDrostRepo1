using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Storage.Repositories
{
  public class OrderRepository
  {

    private const string _path = @"~/home/blake/revature/blake_code/data/orders.xml";
    public List<Order> Orders { get; set; }

    private OrderRepository()
    {
      Orders = new List<Order>();
      //Orders.Add(new Order(new Customer(), new Product(), new Store()));
    }

    public Order GetOrder(int index)
    {
      try
      {
        return Orders[index];
      }
      catch
      {
        return null;
      }
    }

    public void makeOrder(Customer c, Product p, Store s)
    {
      Orders.Add(new Order());
    }

    private static OrderRepository _orderRepository;

    //creating a property
    public static OrderRepository Instance
    {
      get
      {
        if (_orderRepository == null)
        {
          //create an instance of store repository
          _orderRepository = new OrderRepository();
        }
        return _orderRepository;
      }
    }
  }
}