using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace SimpleShop.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductServices _productServices;

        public HomeController (ILogger<HomeController> logger, ProductServices productServices)
        {
            _logger = logger;
            _productServices = productServices;
        }
        public IActionResult Index (int pageIndex = 1, int pageSize = 8, string searchString = null, string sortOrder = "asc", double? minPrice = 0, double? maxPrice = 0)
        {
            var products = _productServices.GetProducts(pageIndex, pageSize, searchString, sortOrder, minPrice, maxPrice);
            var totalPage = _productServices.GetProductCount();
            int numSize = (int)Math.Ceiling((totalPage / (float)pageSize));

            ViewBag.MinPrice = minPrice != 0 ? minPrice : null;
            ViewBag.MaxPrice = maxPrice != 0 ? maxPrice : null;
            ViewBag.SearchString = !string.IsNullOrEmpty(searchString) ? searchString : null;
            ViewBag.PageSize = numSize;

            return View(products);
        }
    }
}
