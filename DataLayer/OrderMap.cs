using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSharp.Framework;
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
            entityBuilder.HasOne(o => o.User).WithMany().OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            entityBuilder.HasOne(o => o.Cart).WithMany().OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

        }
    }
}
