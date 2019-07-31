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
    public class OrderController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IUserService userService;


        public OrderController(IProductService _productService, IUserService _userService)
        {
            productService = _productService;
            userService = _userService;
        }


        // GET: api/Order/5
        [HttpGet("{id}")]
        public List<Order> GetUserOrder(Guid Uid)
        {
            var orders = userService.getUserOrders(Uid).ToList();
            return orders;
        }


        // POST: api/Order
        [HttpPost("Submit/{userId}")]
        public void SubmitOrder(Guid userId)
        {
            userService.SubmitOrder(userId);

        }

    }
}