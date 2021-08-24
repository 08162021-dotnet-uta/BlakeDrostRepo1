using System;
using System.Collections.Generic;
using Project0.StoreApplication.Client.Singletons;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Repositories;
using Serilog;



namespace Project0.StoreApplication.Client
{
  /// <summary>
  /// Defines the Program Class
  /// </summary>
  internal class Program
  {
    private static readonly StoreRepository _storeRepo = StoreRepository.Instance;
    private static readonly CustomerSingleton _custRepo = CustomerSingleton.Instance;
    private static readonly ProductRepository _prodRepo = ProductRepository.Instance;
    private static OrderRepository _orderRepo = OrderRepository.Instance;
    private const string logFilePath = @"/pathway to logs.txt";

    /// <summary>
    /// Defines the Main Method
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
      Run();
    }

    /// <summary>
    /// 
    /// </summary>
    static void Run()
    {
      //Log.Logger = new LoggerConfiguration().WriteTo.File(logFilePath).CreateLogger();
      MakeOrder();
    }

    //Generic Output
    private static void Output<T>(List<T> data)
    {
      var count = 0;
      foreach (var x in data)
      {
        count++;
        System.Console.WriteLine(count + " - " + x);
      }
    }
    static Customer SelectCustomer()
    {
      PrintAllCustomers();
      var cr = _custRepo.Customers;
      Console.Write("Select a Customer: ");
      return (cr[int.Parse(Console.ReadLine()) - 1]);
    }

    static void PrintAllCustomers()
    {
      var count = 0;
      foreach (var curCust in _custRepo.Customers)
      {
        count++;
        System.Console.WriteLine(count + " - " + curCust);
      }
    }

    static void PrintAllStoreLocations()
    {
      var count = 0;
      foreach (var store in _storeRepo.Stores)
      {
        count++;
        System.Console.WriteLine(count + " - " + store);
      }
    }

    static Store SelectStore()
    {
      PrintAllStoreLocations();

      var sr = _storeRepo.Stores;
      Console.Write("Select a Store: ");
      return (sr[int.Parse(Console.ReadLine()) - 1]);
    }

    /*
        static void PrintAllProducts()
        {
          var count = 0;
          var productRepository = new ProductRepository();
          foreach (var product in productRepository.Products)
          {
            count++;
            System.Console.WriteLine(count + " - " + product);
          }
        }

        static Product SelectProduct()
        {
          PrintAllProducts();
          var pr = new ProductRepository().Products;
          Console.Write("Select a Product: ");
          return (pr[int.Parse(Console.ReadLine()) - 1]);
        }
    */
    static void MakeOrder()
    {
      Output<Customer>(_custRepo.Customers);
      /*
      _orderRepo.makeOrder(SelectCustomer(), SelectProduct(), SelectStore());

      foreach (var order in _orderRepo.Orders)
      {
        System.Console.WriteLine(order);
      }
      */
    }
    static void PrintAllOrders()
    {
      foreach (var order in _orderRepo.Orders)
      {
        System.Console.WriteLine(order);
      }
    }
  }
}
