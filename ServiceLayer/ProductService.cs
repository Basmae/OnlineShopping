using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using RepositoryLayer;

namespace ServiceLayer
{
    public class ProductService : IProductService
    {
        private IRepository<User> userRepository;
        private IRepository<Product> productRepository;
        private IRepository<Order> orderRepository;
        private IRepository<Image> imageRepository;
        private IRepository<Cart> cartRepository;

        public ProductService(IRepository<User> _userRepository, IRepository<Product> _productRepository,
            IRepository<Order> _orderRepository, IRepository<Image> _imageRepository,
            IRepository<Cart> _cartRepository)
        {
            userRepository = _userRepository;
            productRepository = _productRepository;
            orderRepository = _orderRepository;
            imageRepository = _imageRepository;
            cartRepository = _cartRepository;
        }

        public void AddImage(Image image)
        {
            imageRepository.Insert(image);
        }

        public void AddProduct(Product product)
        {
            productRepository.Insert(product);
        }

        public IEnumerable<Product> filterProducts(double min, double max)
        {
            var productList = productRepository.GetAll();
            List<Product> products = new List<Product>();
            foreach(var item in productList)
            {
                if (item.Price >= min && item.Price <= max)
                    products.Add(item);
            }
            return products;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return productRepository.GetAll();
        }

        public Product GetProduct(Guid ProductID)
        {
            Product product= productRepository.Get(ProductID);
            
            return product;
        }

        public List<Image> GetProductImages(Guid productId)
        {
            var images = imageRepository.GetAll();
            List<Image> productImages = new List<Image>();
            foreach(var item in images)
            {
                if (item.ProductId == productId)
                    productImages.Add(item);
            }
            return productImages;
        }

        public bool ProductIsAvailable(Guid ProductId)
        {
            Product product = productRepository.Get(ProductId);
            if (product != null && product.Quantity > 0)
                return true;
            else
                return false;
        }

        public void updateProduct(Product product)
        {
            productRepository.Update(product);
        }
    }
}
