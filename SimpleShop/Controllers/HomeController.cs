using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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

        public IActionResult Index (int pageIndex = 1, int pageSize = 8, string searchString = null, string sortOrder = "asc", double? minPrice = 0, double? maxPrice = 0)
        {
            var products = _productServices.GetProducts(pageIndex, pageSize, searchString, sortOrder, minPrice, maxPrice);
            var totalPage = products.Count();
            int numSize = (int)Math.Ceiling((totalPage / (float)pageSize));
            
            ViewBag.MinPrice = minPrice != 0 ? minPrice : null;
            ViewBag.MaxPrice = maxPrice != 0 ? maxPrice : null;
            ViewBag.SearchString = !string.IsNullOrEmpty(searchString) ? searchString : null;
            ViewBag.PageSize = numSize;

            return View(products);
        }

        //[HttpGet]
        //public IActionResult FilterProduct (string sortorder = "asc", double? minprice = 0, double? maxprice = 0)
        //{
        //    var products = _productServices.GetProducts(sortorder, minprice, maxprice);

        //    return ViewComponent("Product", new { ts = products });
        //}
    }
}