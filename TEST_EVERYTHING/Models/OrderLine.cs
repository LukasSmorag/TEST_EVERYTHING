using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEST_EVERYTHING.Models
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int Quantity { get; set; }
    }
}