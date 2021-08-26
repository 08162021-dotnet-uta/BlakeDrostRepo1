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
    private static readonly StoreSingleton _storeRepo = StoreSingleton.Instance;
    private static readonly CustomerSingleton _custRepo = CustomerSingleton.Instance;
    private static readonly ProductSingleton _prodRepo = ProductSingleton.Instance;
    //private static OrderRepository _orderRepo = OrderSingleton.Instance;
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
      Console.WriteLine(SelectCustomer());
      Console.WriteLine(SelectStore());
      Console.WriteLine(SelectProduct());
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
      Output(_custRepo.Customers);
      Console.Write("Select a Customer: ");
      return (_custRepo.Customers[int.Parse(Console.ReadLine()) - 1]);
    }
    static Store SelectStore()
    {
      Output(_storeRepo.Stores);
      Console.Write("Select a Store: ");
      return (_storeRepo.Stores[int.Parse(Console.ReadLine()) - 1]);
    }

    static Product SelectProduct()
    {
      Output(_prodRepo.Products);
      Console.Write("Select a Product: ");
      return (_prodRepo.Products[int.Parse(Console.ReadLine()) - 1]);
    }
  }
}