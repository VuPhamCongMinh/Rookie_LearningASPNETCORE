using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SimpleShop.Controllers
{
    public class HomeController : Controller
    {
        private ProductServices _productServices;

        public HomeController (ProductServices productServices)
        {
            _productServices = productServices;
        }

        public IActionResult Index ()
        {
            IEnumerable<ProductDTO> products = _productServices.GetProducts();
            return View(products);
        }

    }
}