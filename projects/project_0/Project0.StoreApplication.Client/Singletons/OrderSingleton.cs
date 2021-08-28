using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Repositories;

namespace Project0.StoreApplication.Client.Singletons
{
  public class OrderSingleton
  {
    private static OrderSingleton _orderSingleton;
    private static OrderRepository _orderRepository = new OrderRepository();
    //public List<Order> Orders { get; set; }
    public static OrderSingleton Instance
    {
      get
      {
        if (_orderSingleton == null)
        {
          _orderSingleton = new OrderSingleton();
        }
        return _orderSingleton;
      }
    }

    private OrderSingleton()
    {
      _orderRepository.Select();
    }

    public void AddToOrderRepository(Store s, Product p)
    {
      _orderRepository.AddOrder(s, p);
      //Orders = _orderRepository.GetOrders();
    }

    //Java convention getter: needs to be changed to C# convention getter
    public OrderRepository getRepo()
    {
      return _orderRepository;
    }
  }
}