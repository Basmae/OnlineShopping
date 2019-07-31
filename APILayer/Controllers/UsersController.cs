using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService _userService)
        {
            userService = _userService;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> GetUser()
        {
            return userService.getAllUsers().ToList();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public User GetUser(Guid id)
        {
            var user = userService.getUser(id);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        // GET: api/Users/name
        [HttpGet("Name/{UserName}")]
        public User GetUserByName(string UserName)
        {
            return userService.GetUserByName(UserName);
        }
        // GET: api/Users/5
        [HttpGet("cart/{id}")]
        public IEnumerable<Cart> GetUserCarts(Guid id)
        {
            var userCarts = userService.getCart(id).ToList();
            return userCarts;
        }



        // POST: api/Users
        [HttpPost]
        public void PostUser(User user)
        {
            userService.AddUser(new User
            {
                ID = Guid.NewGuid(),
                Name = user.Name
            });

            // return CreatedAtAction("GetUser", new { id = user.UserID }, user);
        }


        [HttpGet("Exist/{UserName}")]
        public bool UserExists(string userName)
        {
            return userService.IsAvailable(userName);
        }

    }
}