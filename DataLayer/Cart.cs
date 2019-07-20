using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class Cart:BaseEntity
    {
        
        public User User { get; set; }

        public Product Product { get; set; }
       
        public int Quantity { get; set; }

        public double Price { get; set; }

        public bool IsSubmitted { get; set; }
    }
}
