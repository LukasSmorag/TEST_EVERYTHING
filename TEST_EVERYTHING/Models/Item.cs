using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEST_EVERYTHING.Models
{
    public class Item
    {
        public Movie Movie { get; set; }
        public int Quantity { get; set; }

        public Item()
        {     
        }

        public Item(Movie movie, int quantity)
        {
            this.Movie = movie;
            this.Quantity = quantity;
        }
    }
}