using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TEST_EVERYTHING.Models;

namespace TEST_EVERYTHING.ViewModels
{
    public class OrderLineItemViewModel
    {
        //ACTION METHOD IN ORDER CONTROLLER
        public Order Order { get; set; }
        public virtual ICollection<OrderLine> LineItems { get; set; }
    }
}