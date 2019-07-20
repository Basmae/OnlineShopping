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
    public class CartsController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IUserService userService;


        public CartsController(IProductService _productService, IUserService _userService)
        {
            productService = _productService;
            userService = _userService;
        }


        // GET: api/Carts/5
        [HttpGet("{id}")]
        public ActionResult<List<Cart>> GetCart(Guid Uid)
        {
            var cart = userService.getCart(Uid).ToList();

            if (cart == null)
            {
                return NotFound();
            }

            return cart;
        }


        // POST: api/Carts
        [HttpPost]
        public void PostCart(Cart cart)
        {
            userService.AddTOCart(new Cart
            {
                ID = Guid.NewGuid(),
                IsSubmitted = false,
                Price = cart.Price,
                Product = cart.Product,
                Quantity = cart.Quantity,
                User = cart.User
            });

        }

       
    }
}