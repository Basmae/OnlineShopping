using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class OrderMap
    {
        public OrderMap(EntityTypeBuilder<Order> entityBuilder)
        {
            entityBuilder.HasKey(o=>o.ID);
            entityBuilder.HasOne(o => o.User);
            entityBuilder.HasOne(o => o.Cart);
        }
    }
}
