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
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
    //private static readonly CustomerSingleton _custSingleton = CustomerSingleton.Instance;
    private static readonly ProductSingleton _prodSingleton = ProductSingleton.Instance;
    private static OrderSingleton _orderSingleton = OrderSingleton.Instance;
    private const string logFilePath = @"/pathway to logs.txt";
    private Product tempProduct;  //For selection purposes
    private Store tempStore;      //For selection purposes

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
      Console.WriteLine("Welcome Valued Customer!");
      Console.WriteLine("Your previous purchase are listed below.");
      PrintAllOrders();
      //Log.Logger = new LoggerConfiguration().WriteTo.File(logFilePath).CreateLogger();
      var tempStore = SelectStore();
      //Console.WriteLine(SelectStore());
      var tempProduct = SelectProduct();
      //Console.WriteLine(SelectProduct());
      Console.WriteLine("The Selected Store is : " + tempStore);
      //*******NEEDS IMPLEMENTATION*******
      //Show previous orders from this location.
      Console.WriteLine("The selected product is : " + tempProduct);
      //Prompt User for Confirmation of an Order
      //Add the order containing the tempStore and tempProduct
      if (ConfirmPurchase())
      {
        _orderSingleton.AddToOrderRepository(tempStore, tempProduct);
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

  }
}