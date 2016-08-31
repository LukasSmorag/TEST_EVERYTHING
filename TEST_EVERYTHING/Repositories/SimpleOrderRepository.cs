using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST_EVERYTHING.DataLayer;
using TEST_EVERYTHING.Models;

namespace Repository
{
    public class SimpleOrderRepository: IDisposable
    {
        readonly MovieContext _context = new MovieContext();

        public void AddNewOrder(Order order)
        {
            _context.Orders.Add(order);
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders.Find(id);
        }

        public List<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }

        public Order GetOrderWithLineItems(int id) {
            Order order = _context.Orders.Include("Orders").First(o => o.OrderId == id);
            return order;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
