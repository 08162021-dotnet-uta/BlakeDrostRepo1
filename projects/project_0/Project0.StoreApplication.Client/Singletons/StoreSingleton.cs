using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Repositories;

namespace Project0.StoreApplication.Client.Singletons
{
  public class StoreSingleton
  {
    private static StoreSingleton _storeSingleton;
    private static readonly StoreRepository _storeRepository = new StoreRepository();
    public List<Store> Stores { get; }
    public static StoreSingleton Instance
    {
      get
      {
        if (_storeSingleton == null)
        {
          _storeSingleton = new StoreSingleton();
        }
        return _storeSingleton;
      }
    }

    /// <summary>
    /// Populates the List of Stores property for the Singleton
    /// </summary>
    private StoreSingleton()
    {
      Stores = _storeRepository.Select();
    }
  }
}