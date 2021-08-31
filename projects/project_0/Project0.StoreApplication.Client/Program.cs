using System;
using System.Collections.Generic;
using Project0.StoreApplication.Client.Singletons;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Adapters;
using Project0.StoreApplication.Storage.Repositories;
using Serilog;



namespace Project0.StoreApplication.Client
{
  /// <summary>
  /// Defines the Program Class
  /// </summary>
  internal class Program
  {
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
    //private static readonly CustomerSingleton _custSingleton = CustomerSingleton.Instance;
    private static readonly ProductSingleton _prodSingleton = ProductSingleton.Instance;
    private static OrderSingleton _orderSingleton = OrderSingleton.Instance;
    private static string genericPath = @"/home/blake/revature/blake_code/data/";
    private static readonly FileAdapter _fileAdapter = new FileAdapter();
    private const string logFilePath = @"/home/blake/revature/blake_code/data/logFiles.txt";
    //private Product tempProduct;  //For selection purposes
    //private Store tempStore;      //For selection purposes

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
      Log.Logger = new LoggerConfiguration().WriteTo.File(logFilePath).CreateLogger();
      Log.Information("*****Begin Program*****");
      Console.WriteLine("Welcome Valued Customer!");
      Console.Write("Would you like to see all previous orders? ");
      if (Confirmation())
      {
        Log.Information("The user wants to see all their orders.");
        PrintAllOrders();
      }
      else
      {
        Log.Information("The user chose not to see their orders.");
      }
      var tempStore = SelectStore();
      //Console.WriteLine(SelectStore());
      var tempProduct = SelectProduct();
      //Console.WriteLine(SelectProduct());
      Console.WriteLine("The Selected Store is : " + tempStore);
      Console.Write("Would you like to see all purchase from this Store? ");
      if (Confirmation())
      {
        Log.Information("The user wants to see all orders from the selected store.");
        Output(GetOrderFromStore(tempStore));
      }
      else
      {
        Log.Information("The user chose not to see all orders from the selected store.");
      }
      Console.WriteLine("The selected product is : " + tempProduct);
      if (ConfirmPurchase())
      {
        Log.Information("The user confirmed the order.");
        Order curOrder = new Order() { Store = tempStore, Product = tempProduct };
        _orderSingleton.AddToOrderRepository(tempStore, tempProduct);
        AddOrderToStore(tempStore, curOrder);
      }
      else
      {
        Log.Information("The user chose not to confirm the order.");
      }
    }

    private static void PrintAllOrders()
    {
      int count = 0;
      foreach (var o in _orderSingleton.getRepo().GetOrders())
      {
        count++;
        Console.WriteLine(count + " - " + o);
      }
    }

    static bool ConfirmPurchase()
    {
      Console.Write("Confirm Purchase (Y/N): ");
      if (Console.ReadLine() == "Y")
      {
        return true;
      }
      return false;
    }
    static bool Confirmation()
    {
      Console.Write("(Y/N): ");
      if (Console.ReadLine() == "Y")
      {
        return true;
      }
      else
        return false;
    }

    //Generic Output
    static void Output<T>(List<T> data)
    {
      var count = 0;
      foreach (var x in data)
      {
        count++;
        System.Console.WriteLine(count + " - " + x);
      }
    }

    /*static Customer SelectCustomer()
    {
      Output(_custSingleton.Customers);
      Console.Write("Select a Customer: ");
      return (_custSingleton.Customers[int.Parse(Console.ReadLine()) - 1]);
    }*/
    static Store SelectStore()
    {
      Output(_storeSingleton.Stores);
      Console.Write("Select a Store: ");
      return (_storeSingleton.Stores[int.Parse(Console.ReadLine()) - 1]);
    }

    static Product SelectProduct()
    {
      Output(_prodSingleton.Products);
      Console.Write("Select a Product: ");
      return (_prodSingleton.Products[int.Parse(Console.ReadLine()) - 1]);
    }

    static void AddOrderToStore(Store s, Order o)
    {
      string ThePath = genericPath + s.Location + ".xml";
      List<Order> tempOrders;
      if (_fileAdapter.ReadFromFile<Order>(ThePath) == null)
      {
        _fileAdapter.WriteToFile<Order>(ThePath, new List<Order>());
      }
      else
      {
        tempOrders = _fileAdapter.ReadFromFile<Order>(ThePath);
        tempOrders.Add(o);
        _fileAdapter.WriteToFile<Order>(ThePath, tempOrders);
      }
    }
    static List<Order> GetOrderFromStore(Store s)
    {
      string ThePath = genericPath + s.Location + ".xml";
      return _fileAdapter.ReadFromFile<Order>(ThePath);
    }
  }
}