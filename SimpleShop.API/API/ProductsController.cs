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
        [Authorize("Admin")]
        [HttpGet]
        public async Task<ActionResult<Product>> GetProducts ()
        {
            var products = await _productService.GetProducts();
            return Ok(products);
        }

        [AllowAnonymous]
        [HttpGet("/api/GetFilteredProducts")]
        public ActionResult<Product> GetFilteredProducts (int pageIndex, int pageSize, string searchString, string sortOrder, double? minPrice, double? maxPrice, int cate)
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

        [AllowAnonymous]
        [HttpGet("/api/GetMostOrderedProducts")]
        public ActionResult<Product> GetMostOrderedProducts ()
        {
            var products = _productService.GetMostOrderedProducts();
            if (products.Count() <= 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(products);
            }
        }

        [AllowAnonymous]
        [HttpGet("/api/GetNewlyAddProducts")]
        public ActionResult<Product> GetNewlyAddProducts ()
        {
            var products = _productService.GetNewlyAddProducts();
            if (products.Count() <= 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(products);
            }
        }

        //GET: api/Products/5
        [AllowAnonymous]
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

        [Authorize("Admin")]
        [HttpPost]
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
        [Authorize("Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> PutProduct (int id, [FromForm] ProductPostRequest request)
        {
            var product = await _productService.PutProduct(id, request);

            if (product is null)
            {
                return BadRequest();
            }
            return Ok(product);
        }
        [Authorize("Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct (int id)
        {
            var isDeleteSuccessful = await _productService.DeleteProduct(id);
            if (isDeleteSuccessful)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}

