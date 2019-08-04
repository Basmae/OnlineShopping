using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using RepositoryLayer;

namespace ServiceLayer
{
    public class UserService : IUserService
    {
        
        private IRepository<User> userRepository;
        private IRepository<Product> productRepository;
        private IRepository<Order> orderRepository;
        private IRepository<Cart> cartRepository;

        public UserService(IRepository<User> _userRepository, IRepository<Product> _productRepository ,
            IRepository<Order> _orderRepository,
            IRepository<Cart> _cartRepository)
        {
            userRepository = _userRepository;
            productRepository = _productRepository;
            orderRepository = _orderRepository;
            cartRepository = _cartRepository;
        }
        public void AddTOCart(Cart cart)
        {
            cartRepository.Insert(cart);
        }

        public void AddUser(User user)
        {
            userRepository.Insert(user);
        }

        public Cart DeleteCart(Cart cart)
        {
           // var delCart= cartRepository.Get(cart.ID);
            cartRepository.Delete(cart);
            return cart;
        }

        public IEnumerable<User> getAllUsers()
        {
            return userRepository.GetAll();
        }

        public IEnumerable<Cart> getCart(Guid userId)
        {
            var carts = cartRepository.GetAll();
            List<Cart> UserCarts=new List<Cart>();
            foreach(var item in carts)
            {
                if (item.UserId == userId && item.IsSubmitted==false)
                    UserCarts.Add(item);
            }
            return UserCarts;
        }

        public User getUser(Guid userId)
        {
           return userRepository.Get(userId);
        }

        public bool IsAvailable(string userName)
        {
            var users = userRepository.GetAll();
            foreach(var item in users)
            {
                if (item.Name == userName)
                    return true;
            }
            return false;
        }

        public User GetUserByName(string userName)
        {
            var users = userRepository.GetAll();
            foreach (var item in users)
            {
                if (item.Name == userName)
                    return item;
            }
            return null;
        }

        public void SubmitOrder(Guid userId)
        {
            var cartlist = getCart(userId);
            foreach(var item in cartlist)
            {
                orderRepository.Insert(new Order
                {
                    UserId = userId,
                    CartId = item.ID,
                    ID = Guid.NewGuid()
                });
                item.IsSubmitted = true;
                cartRepository.Update(item);
                var product = productRepository.Get(item.ProductId);
                product.Quantity -= item.Quantity;
                productRepository.Update(product);
            }

        }

        public IEnumerable<Order> getUserOrders(Guid userId)
        {
            var orders = orderRepository.GetAll();
            List<Order> UserOrders = new List<Order>();
            foreach(var item in orders)
            {
                if (item.UserId == userId)
                    UserOrders.Add(item);
            }
            return UserOrders;
        }
    }
}
