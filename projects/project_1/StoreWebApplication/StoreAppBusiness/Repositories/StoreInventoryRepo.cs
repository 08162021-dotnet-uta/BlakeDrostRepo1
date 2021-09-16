using System;
using Microsoft.EntityFrameworkCore;
using StoreAppBusiness.Interfaces;
using StoreAppDBContext.Models;
using StoreAppModels.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppBusiness.Repositories {
    public class StoreInventoryRepo : IModelMapper<StoreInventory, ViewStoreInventory> {
        private readonly StoreDBContext _context;
        public StoreInventory ViewToEF(ViewStoreInventory view) {
            Store s = _context.Stores.FromSqlRaw<Store>("SELECT * FROM Stores WHERE StoreLocation = {0}", view.Store.Location).FirstOrDefault();
            Product p = _context.Products.FromSqlRaw<Product>("SELECT * FROM Products WHERE ProductName = {0}", view.Product.Name).FirstOrDefault();
            StoreInventory si = _context.StoreInventorys.FromSqlRaw<StoreInventory>("SELECT * FROM StoreInventorys WHERE StoreID = {0} AND ProductID = {1}", s.StoreId, p.ProductId).FirstOrDefault();
            return si;
        }
        public ViewStoreInventory EFToView(StoreInventory ef) {
            ViewStore s = new ViewStore(ef.Store.StoreLocation);
            ViewProduct p = new ViewProduct(ef.Product.ProductName, ef.Product.ProductPrice);
            ViewStoreInventory si = new ViewStoreInventory(s, p, ef.Quantity);
            return si;
        }
    }
}
