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
    /// Will prompt the user for selections and display information
    /// Drives the program
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
      Console.Write("Would you like to see all purchase from " + tempStore + "? ");
      if (Confirmation())
      {
        Log.Information("The user wants to see all orders from the selected store.");
        Output(GetOrderFromStore(tempStore));
      }
      else
      {
        Log.Information("The user chose not to see all orders from the selected store.");
      }
      Console.WriteLine("************************************************************");
      var tempProduct = SelectProduct();
      Console.Write("Would you like to purchase " + tempProduct.ProductName + "? ");
      if (Confirmation())
      {
        Log.Information("The user confirmed the order.");
        Order curOrder = new Order() { Store = tempStore, Product = tempProduct };
        _orderSingleton.AddToOrderRepository(tempStore, tempProduct);
        AddOrderToStore(tempStore, curOrder);
        Console.WriteLine("You have placed an order!");
      }
      else
      {
        Log.Information("The user chose not to confirm the order.");
      }
    }

    /// <summary>
    /// Will write to console all orders made across all store locations
    /// </summary>
    private static void PrintAllOrders()
    {
      int count = 0;
      foreach (var o in _orderSingleton.getRepo().GetOrders())
      {
        count++;
        Console.WriteLine(count + " - " + o);
      }
      Console.WriteLine("************************************************************");
    }

    /// <summary>
    /// Prompts the user for a yes or no response => Y/N.
    /// Will return true if the user input Y.
    /// Will return false for any other input.
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Outputs a List of objects to the console.
    /// Takes one parameter: A List of objects.
    /// If there are no elements, will print a special case.
    /// </summary>
    /// <param name="data"></param>
    /// <typeparam name="T"></typeparam>
    static void Output<T>(List<T> data)
    {
      if (data.Count == 0)
      {
        Console.WriteLine("There is nothing here!");
      }
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
    /// <summary>
    /// Will print the store locations to console.
    /// Prompts the user for a selection
    /// Returns the selection as a Store
    /// </summary>
    /// <returns></returns>
    static Store SelectStore()
    {
      Output(_storeSingleton.Stores);
      Console.Write("Select a Store: ");
      return (_storeSingleton.Stores[int.Parse(Console.ReadLine()) - 1]);
    }

    /// <summary>
    /// Will print the products to console.
    /// Prompts the user for a selection
    /// Returns the selection as a Product
    /// </summary>
    /// <returns></returns>
    static Product SelectProduct()
    {
      Output(_prodSingleton.Products);
      Console.Write("Select a Product: ");
      return (_prodSingleton.Products[int.Parse(Console.ReadLine()) - 1]);
    }

    /// <summary>
    /// Will add a new order to a Store's list of orders.
    /// Takes the parameters: Store, Order.
    /// Will create a new file if no orders have been made at a store location.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="o"></param>
    static void AddOrderToStore(Store s, Order o)
    {
      string ThePath = genericPath + s.StoreLocation + ".xml";
      List<Order> tempOrders;
      if (_fileAdapter.ReadFromFile<Order>(ThePath) == null)
      {
        _fileAdapter.WriteToFile<Order>(ThePath, new List<Order>() { o });
      }
      else
      {
        tempOrders = _fileAdapter.ReadFromFile<Order>(ThePath);
        tempOrders.Add(o);
        _fileAdapter.WriteToFile<Order>(ThePath, tempOrders);
      }
    }

    /// <summary>
    /// Will return a list of Orders.
    /// Takes the parameter: Store
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    static List<Order> GetOrderFromStore(Store s)
    {
      string ThePath = genericPath + s.StoreLocation + ".xml";
      if (_fileAdapter.ReadFromFile<Order>(ThePath) == null)
      {
        _fileAdapter.WriteToFile<Order>(ThePath, new List<Order>());
      }
      return _fileAdapter.ReadFromFile<Order>(ThePath);
    }
  }
}