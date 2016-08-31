using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEST_EVERYTHING.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        private ICollection<OrderLine> orders;

        public Order()
        {
            orders = new List<OrderLine>();
        }

        public ICollection<OrderLine> Orders
        {
            get { return orders; }
            set { orders = value; }
        }
        

        public void AddOrderLine(OrderLine orderLine) {
            orders.Add(orderLine);
        }

        public void DeleteOrderLine(OrderLine orderLine)
        {
            if (orders != null)
            {
                //List.Remove checks on the item Id by naming conventios, so this should work
                orders.Remove(orderLine);
            }
        }
    }
}