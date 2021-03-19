using Application.Services;
using Microsoft.AspNetCore.Mvc;

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
            var products = _productServices.GetProducts();
            return View(products);
        }

    }
}