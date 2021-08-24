using System.Collections.Generic;
using Project0.StoreApplication.Domain.Interfaces;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Adapters;

namespace Project0.StoreApplication.Storage.Repositories
{
  public class CustomerRepository : IRepository<Customer>
  {
    //File Path for storage of customers
    private const string _path = @"~/home/blake/revature/blake_code/data/customers.xml";
    private static readonly FileAdapter _fileAdapter = new FileAdapter();
    //List of all customers
    public List<Customer> Customers { get; set; }

    //Private constructor for singleton usage
    public CustomerRepository()
    {
      if (_fileAdapter.ReadFromFile<Customer>(_path) == null)
      {
        _fileAdapter.WriteToFile<List<Customer>>(_path, new List<Customer>());
      }
      //Customers = new List<Customer>(){
      //new Customer(){ Name = "Bill"},
      //new Customer(){ Name = "Anne"},
      //new Customer(){ Name = "Taylor"}
      //};
    }

    public Customer GetCustomer(int index)
    {
      try
      {
        return Customers[index];
      }
      catch
      {
        return null;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool Insert()
    {
      throw new System.NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Customer Update()
    {
      throw new System.NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List<Customer> Select()
    {
      return _fileAdapter.ReadFromFile<List<Customer>>(_path);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    private static CustomerRepository _customerRepository;

    //creating a property
    public static CustomerRepository Instance
    {
      get
      {
        if (_customerRepository == null)
        {
          //create an instance of customer repository
          _customerRepository = new CustomerRepository();
        }
        return _customerRepository;
      }
    }
  }
}