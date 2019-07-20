using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(Guid ProductID);
        bool ProductIsAvailable(Guid ProductId);
        IEnumerable<Product> filterProducts(double min, double max);
        void updateProduct(Product product);
        void AddProduct(Product product);
        IEnumerable<Image> GetProductImages(Guid productId);

    }
}
