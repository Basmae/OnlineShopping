using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class CartMap
    {
        public CartMap(EntityTypeBuilder<Cart> entityBuilder)
        {
            entityBuilder.HasKey(c => c.ID);
            entityBuilder.Property(c=>c.Price).IsRequired();
            entityBuilder.Property(c => c.Quantity).IsRequired();
            entityBuilder.Property(c => c.IsSubmitted).IsRequired();
            entityBuilder.HasOne(c => c.User);
            entityBuilder.HasOne(c => c.Product);
        }
    }
}
