using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IUserService
    {
        bool IsAvailable(string userName);
        IEnumerable<Cart> getCart(Guid userId);
        void AddTOCart(Cart cart);
        void SubmitOrder(Guid userId);
        IEnumerable<Order> getUserOrders(Guid userId);
        Task<User> getUser(Guid userId);
        User GetUserByName(string userName);
        void AddUser(User user);
        Cart DeleteCart(Cart cart);
        IEnumerable<User> getAllUsers();
    }
}
