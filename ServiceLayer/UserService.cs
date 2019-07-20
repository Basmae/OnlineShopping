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
        private IRepository<Image> imageRepository;
        private IRepository<Cart> cartRepository;

        public UserService(IRepository<User> _userRepository, IRepository<Product> _productRepository ,
            IRepository<Order> _orderRepository, IRepository<Image> _imageRepository,
            IRepository<Cart> _cartRepository)
        {
            userRepository = _userRepository;
            productRepository = _productRepository;
            orderRepository = _orderRepository;
            imageRepository = _imageRepository;
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
                if (item.User.ID == userId && item.IsSubmitted==false)
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

        public void SubmitOrder(User user)
        {
            var cartlist = getCart(user.ID);
            foreach(var item in cartlist)
            {
                orderRepository.Insert(new Order
                {
                    User = user,
                    Cart = item,
                    ID = Guid.NewGuid()
                });
                item.IsSubmitted = true;
                cartRepository.Update(item);
            }

        }

        public IEnumerable<Order> getUserOrders(Guid userId)
        {
            var orders = orderRepository.GetAll();
            List<Order> UserOrders = new List<Order>();
            foreach(var item in orders)
            {
                if (item.User.ID == userId)
                    UserOrders.Add(item);
            }
            return UserOrders;
        }
    }
}
