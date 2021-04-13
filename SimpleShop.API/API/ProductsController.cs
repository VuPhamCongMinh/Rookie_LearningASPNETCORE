using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SimpleShop.API.Services;
using SimpleShop.Shared.Models;
using SimpleShop.Shared.ViewModels;
using SimpleShop.Shared.Interfaces;
using System.Linq;

namespace SimpleShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController (IProductService services)
        {
            _productService = services;
        }

        // GET: api/Products
        //[Authorize("Bearer")] 
        [HttpGet]
        public ActionResult<ProductResponse> GetProducts (int pageIndex = 1, int pageSize = 6, string searchString = null, string sortOrder = "asc", double? minPrice = 0, double? maxPrice = 0, int cate = -1)
        {
            var products = _productService.GetFilteredProducts(pageIndex, pageSize, searchString, sortOrder, minPrice, maxPrice, cate);
            if (products.Count() <= 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(new ProductResponse
                {
                    Products = products,
                    Count = _productService.GetProductCount()
                });
            }
        }

        //GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct (int id)
        {
            var product = await _productService.GetProductByID(id);

            if (product == null)
            {
                return NoContent();
            }

            return Ok(product);
        }

        [HttpPost]
        [Authorize("Bearer")]
        public async Task<ActionResult<IEnumerable<Product>>> PostProduct ([FromForm] ProductPostRequest request)
        {
            var product = await _productService.PostProduct(request);
            if (product != null)
            {
                return CreatedAtAction(nameof(GetProduct), new { id = product.productId }, product);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPut("{id}")]
        [Authorize("Bearer")]
        public async Task<ActionResult<Product>> PutProduct (int id, [FromForm] ProductPostRequest request)
        {
            var product = await _productService.PutProduct(id, request);

            if (product is null)
            {
                return BadRequest();
            }
            return Ok(product);
        }

        [HttpDelete("{id}")]
        [Authorize("Bearer")]
        public async Task<ActionResult<IEnumerable<ProductPostRequest>>> DeleteProduct (int id)
        {
            var product = await _productService.DeleteProduct(id);
            return Ok(product);
        }
    }
}

