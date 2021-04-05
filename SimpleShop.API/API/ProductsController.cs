using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SimpleShop.Shared.Services;
using SimpleShop.Shared.Models;
using SimpleShop.Shared.ViewModels;

namespace SimpleShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _services;

        public ProductsController (ProductService services)
        {
            _services = services;
        }

        // GET: api/Products
        //[Authorize("Bearer")] 
        [HttpGet]
        public ActionResult<ProductResponse> GetProducts (int pageIndex, int pageSize, string searchString,
            string sortOrder, double? minPrice, double? maxPrice, int cate)
        {
            var products = _services.GetFilteredProducts(pageIndex, pageSize, searchString, sortOrder, minPrice, maxPrice, cate);
            return Ok(new ProductResponse
            {
                Products = products,
                Count = _services.GetProductCount()
            });
        }

        //GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct (int id)
        {
            var product = await _services.GetProductByID(id);

            if (product == null)
            {
                return NoContent();
            }

            return product;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<ProductCreateRequest>>> PostProduct ([FromForm] ProductCreateRequest request)
        {
            var product = await _productService.PostProduct(request);
            return Ok(product);
        }
        [HttpPut("ProductId")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<ProductUpdateRequest>>> PutProduct (int ProductId, [FromForm] ProductUpdateRequest request)
        {
            var product = await _productService.PutProduct(ProductId, request);
            return Ok(product);
        }
        [HttpDelete("ProductId")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<ProductUpdateRequest>>> DeleteProduct (int ProductId)
        {
            var product = await _productService.DeleteProduct(ProductId);
            return Ok(product);
        }
    }
}

