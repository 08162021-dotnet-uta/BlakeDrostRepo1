using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Storage.Repositories
{
  public class StoreRepository
  {
    private const string _path = @"~/home/blake/revature/blake_code/data/stores.xml";
    public List<Store> Stores { get; set; }

    private StoreRepository()
    {
      Stores = new List<Store>();
    }

    public Store GetStore(int index)
    {
      try
      {
        return Stores[index];
      }
      catch
      {
        return null;
      }
    }

    private static StoreRepository _storeRepository;

    //creating a property
    public static StoreRepository Instance
    {
      get
      {
        if (_storeRepository == null)
        {
          //create an instance of store repository
          _storeRepository = new StoreRepository();
        }
        return _storeRepository;
      }
    }
  }
}