using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayer;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService _productService)
        {
            productService = _productService;
        }

        // GET: api/products
        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllproducts()
        {
            return productService.GetAllProducts().ToList();
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        public async Task<Product> GetproductById(Guid id)
        {
            var product = productService.GetProduct(id);

            if (product == null)
            {
                return null;
            }

            return product;
        }

        // PUT: api/products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Updateproduct(Guid id, Product product)
        {
            if (id != product.ID)
            {
                return BadRequest();
            }


            try
            {
                productService.updateProduct(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await productExists(id)))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/products
        [HttpPost]
        public async void AddProduct(Product product)
        {
            productService.AddProduct(product);

        }

        
        public async Task<bool> productExists(Guid id)
        {
            return productService.ProductIsAvailable(id);
        }

        [HttpGet("Images/{id}")]
        public async Task<IEnumerable<Image>> GetproductImages(Guid id)
        {
            var productImages = productService.GetProductImages(id).ToList();

            return productImages;
        }

        [HttpGet("filter/{min}/{max}")]
        public async Task<IEnumerable<Product>> Getproducts(double min , double max)
        {
            var filteredproducts = productService.filterProducts(min,max).ToList();

            return filteredproducts;
        }
        // POST: api/products/image
        [HttpPost("image")]
        public async void AddImage(Image image)
        {
            productService.AddImage(image);

        }
    }
}