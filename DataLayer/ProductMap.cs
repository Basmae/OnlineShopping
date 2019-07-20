using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class ProductMap
    {
        public ProductMap(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.HasKey(p => p.ID);
            entityBuilder.Property(p => p.ProductName).IsRequired();
            entityBuilder.Property(p => p.Price).IsRequired();
            entityBuilder.Property(p => p.Quantity).IsRequired();
            entityBuilder.HasMany(p => p.Images).WithOne(i => i.Product).HasForeignKey(i => i.ProductId);
        }
    }
}
