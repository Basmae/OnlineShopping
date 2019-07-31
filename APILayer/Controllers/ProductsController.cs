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
        public IEnumerable<Product> Getproduct()
        {
            return productService.GetAllProducts().ToList();
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        public Product Getproduct(Guid id)
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
        public IActionResult Putproduct(Guid id, Product product)
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
                if (!productExists(id))
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
        public void Postproduct(Product product)
        {
            productService.AddProduct(product);

        }

        
        public bool productExists(Guid id)
        {
            return productService.ProductIsAvailable(id);
        }

        [HttpGet("Images/{id}")]
        public IEnumerable<Image> GetproductImages(Guid id)
        {
            var productImages = productService.GetProductImages(id).ToList();

            return productImages;
        }

        [HttpGet("filter/{min}/{max}")]
        public IEnumerable<Product> Getproducts(double min , double max)
        {
            var filteredproducts = productService.filterProducts(min,max).ToList();

            return filteredproducts;
        }
        // POST: api/products/image
        [HttpPost("image")]
        public void PostImage(Image image)
        {
            productService.AddImage(image);

        }
    }
}