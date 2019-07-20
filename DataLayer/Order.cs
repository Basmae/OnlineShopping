using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class Order:BaseEntity
    {
       
        public Cart Cart { get; set; }

        public User User { get; set; }
    }
}
