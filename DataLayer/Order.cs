using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class Order:BaseEntity
    {
       
        public virtual Cart Cart { get; set; }
        public Guid CartId { get; set; }
        public virtual User User { get; set; }
        public Guid UserId { get; set; }

    }
}
