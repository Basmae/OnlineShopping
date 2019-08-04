using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Task<Product> GetProduct(Guid ProductID);
        Task<bool> ProductIsAvailable(Guid ProductId);
        IEnumerable<Product> filterProducts(double min, double max);
        void updateProduct(Product product);
        void AddProduct(Product product);
        List<Image> GetProductImages(Guid productId);
        void AddImage(Image image);

    }
}
