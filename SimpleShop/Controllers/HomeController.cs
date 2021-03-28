using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SimpleShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductServices _productServices;
        public HomeController (ProductServices productServices)
        {
            _productServices = productServices;
        }

        public IActionResult Index (string sortorder = "asc", double? minprice = 0, double? maxprice = 0)
        {
            ViewBag.MinPrice = minprice != 0 ? minprice : null;
            ViewBag.MaxPrice = maxprice != 0 ? maxprice : null;
            var products = _productServices.GetProducts(sortorder, minprice, maxprice);
            return View(products);
        }

        [HttpGet]
        public IActionResult FilterProduct (string sortorder = "asc", double? minprice = 0, double? maxprice = 0)
        {
            var products = _productServices.GetProducts(sortorder, minprice, maxprice);

            return ViewComponent("Product",new { products = products });
        }
    }
}