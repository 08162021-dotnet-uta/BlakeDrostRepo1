using System.Collections.Generic;
using Project0.StoreApplication.Domain.Interfaces;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Adapters;

namespace Project0.StoreApplication.Storage.Repositories
{
  public class CustomerRepository : IRepository<Customer>
  {
    //File Path for storage of customers
    private const string _path = @"/home/blake/revature/blake_code/data/customers.xml";
    private static readonly FileAdapter _fileAdapter = new FileAdapter();

    public CustomerRepository()
    {
      if (_fileAdapter.ReadFromFile<Customer>(_path) == null)
      {
        _fileAdapter.WriteToFile<Customer>(_path, new List<Customer>(){
        new Customer(){ CustomerName = "Bill"},
        new Customer(){ CustomerName = "Anne"},
        new Customer(){ CustomerName = "Taylor"}});
      }
    }

    public bool Insert(List<Customer> entry)
    {
      _fileAdapter.WriteToFile<Customer>(_path, entry);

      return true;
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
      return _fileAdapter.ReadFromFile<Customer>(_path);
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