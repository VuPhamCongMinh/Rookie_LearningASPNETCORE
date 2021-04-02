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
using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;
using SimpleShop.Shared.ViewModels;

namespace SimpleShop.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private const string product_api = "https://localhost:44348/api/products";

        public HomeController (ILogger<HomeController> logger,
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index (int pageIndex = 1, int pageSize = 3, string searchString = null, string sortOrder = "asc", double? minPrice = 0, double? maxPrice = 0)
        {
            #region Define HttpClient & HttpRequest
            var client = _httpClientFactory.CreateClient();
            var url = new UriBuilder(product_api)
            {
                Query = $"pageindex={pageIndex}&pagesize={pageSize}&searchstring={searchString}&sortorder={sortOrder}&minprice={minPrice}&maxprice={maxPrice}"
            };

            var get_product_request = new HttpRequestMessage(HttpMethod.Get, url.ToString());
            var access = await HttpContext.GetTokenAsync("access_token");
            get_product_request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", access);
            #endregion

            var get_product_response = await client.SendAsync(get_product_request);

            ProductResponse productsRespone; int totalPage; // null at first 

            if (get_product_response.IsSuccessStatusCode)
            {
                var get_product_responseData = await get_product_response.Content.ReadAsStringAsync();
                productsRespone = JsonConvert.DeserializeObject<ProductResponse>(get_product_responseData);
                totalPage = productsRespone.Count;
            }
            else
            {
                productsRespone = null;
                totalPage = 0;
                _logger.LogInformation(await get_product_request.Content.ReadAsStringAsync());
            }

            #region Define ViewBag 
            ViewBag.MinPrice = minPrice != 0 ? minPrice : null;
            ViewBag.MaxPrice = maxPrice != 0 ? maxPrice : null;
            ViewBag.SearchString = !string.IsNullOrEmpty(searchString) ? searchString : null;
            ViewBag.TotalProduct = (int)Math.Ceiling((totalPage / (float)pageSize));
            #endregion

            return View(productsRespone.Products);
        }
    }
}
