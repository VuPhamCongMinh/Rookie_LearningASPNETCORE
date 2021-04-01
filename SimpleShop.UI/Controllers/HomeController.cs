using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SimpleShop.Shared.Services;
using SimpleShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleShop.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _productServices;
        private readonly IHttpClientFactory _httpClientFactory;
        private const string product_api = "https://localhost:44348/api/products";

        public HomeController (ILogger<HomeController> logger,
            ProductService productServices,
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _productServices = productServices;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index (int pageIndex = 1, int pageSize = 8, string searchString = null, string sortOrder = "asc", double? minPrice = 0, double? maxPrice = 0)
        {
            #region Define HttpClient & HttpRequest
            var client = _httpClientFactory.CreateClient();
            var url = new UriBuilder(product_api)
            {
                Query = $"pageindex={pageIndex}&pagesize={pageSize}&searchstring={searchString}&sortorder={sortOrder}&minprice={minPrice}&maxprice={maxPrice}"
            };
            #endregion
            var response = await client.GetAsync(url.ToString());

            int totalPage = _productServices.GetProductCount();
            int numSize = (int)Math.Ceiling((totalPage / (float)pageSize));
            IEnumerable<Product> products; // null at first

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<IEnumerable<Product>>(responseData);
            }
            else
            {
                products = Enumerable.Empty<Product>();
                _logger.LogInformation(await response.Content.ReadAsStringAsync());
                totalPage = 0;
                numSize = (int)Math.Ceiling((totalPage / (float)pageSize));
            }

            #region Define ViewBag 
            ViewBag.MinPrice = minPrice != 0 ? minPrice : null;
            ViewBag.MaxPrice = maxPrice != 0 ? maxPrice : null;
            ViewBag.SearchString = !string.IsNullOrEmpty(searchString) ? searchString : null;
            ViewBag.PageSize = numSize;
            #endregion

            return View(products);
        }
    }
}
