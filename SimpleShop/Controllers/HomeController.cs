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

        public IActionResult Index (string sortorder, int min_price_input, int max_price_input)
        {
            var products = _productServices.GetProducts();
            return View(products);
        }

        public IActionResult FilterProduct ()
        {
            return ViewComponent("Product");
        }
    }
}