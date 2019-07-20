using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class Image:BaseEntity
    {
        public string ImageUrl { get; set; }
        public virtual Product Product { get; set; }
        public Guid ProductId { get; set; }
    }
}
