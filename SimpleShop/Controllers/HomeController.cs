using Microsoft.AspNetCore.Mvc;

using SimpleShop.Models;
using System.Diagnostics;

namespace SimpleShop.Controllers
{
    public class HomeController : Controller
    {
        //private ProductDAL _productServices;

        public HomeController()
        {
            //_productServices = productServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}