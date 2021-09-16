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
    public class OrderRepo : IModelMapper<Order, ViewOrder> {
        private readonly StoreDBContext _context;
        public Order ViewToEF(ViewOrder view) {
            Order o = _context.Orders.FromSqlRaw<Order>("SELECT * FROM Orders WHERE OrderId = {0}", view.OrderID).FirstOrDefault();
            return o;
        }
        public ViewOrder EFToView(Order ef) {
            ViewCustomer c = new ViewCustomer(ef.Customer.CustomerFirstName, ef.Customer.CustomerLastName, ef.Customer.CustomerUsername, ef.Customer.CustomerPassword);
            ViewStore s = new ViewStore(ef.Store.StoreLocation);
            ViewOrder o = new ViewOrder(ef.OrderId, ef.OrderDate, c, s, ef.TotalPrice);
            return o;
        }
    }
}
