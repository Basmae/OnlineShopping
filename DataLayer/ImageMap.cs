using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class ImageMap
    {
        public ImageMap(EntityTypeBuilder<Image> entityBuilder)
        {
            entityBuilder.HasKey(i => i.ID);
            entityBuilder.Property(i => i.ImageUrl).IsRequired();
            entityBuilder.HasOne(i => i.Product).WithMany(p => p.Images).HasForeignKey(i => i.ProductId);
        }
    }
}
