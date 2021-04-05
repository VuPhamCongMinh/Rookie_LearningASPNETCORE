using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SimpleShop.Shared.Constant;
using SimpleShop.Shared.Models;
using SimpleShop.Shared.ViewModels;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SimpleShop.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController (ILogger<HomeController> logger,
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index (int pageIndex = 1, int pageSize = 6, string searchString = null, string sortOrder = "asc", double? minPrice = 0, double? maxPrice = 0, int cate = -1)
        {
            #region Define HttpClient & HttpRequest
            var client = _httpClientFactory.CreateClient();
            var url = new UriBuilder(ApiUrl.PRODUCTS_API_URL)
            {
                Query = $"pageindex={pageIndex}&pagesize={pageSize}&searchstring={searchString}&sortorder={sortOrder}&minprice={minPrice}&maxprice={maxPrice}&cate={cate}"
            };
            var get_product_request = new HttpRequestMessage(HttpMethod.Get, url.ToString());
            // 2 dòng dưới dùng khi muốn chèn access token vào httpclient đề lấy api đã dc bảo mật
            var access = await HttpContext.GetTokenAsync("access_token");
            get_product_request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", access);
            #endregion

            var get_product_response = await client.SendAsync(get_product_request);

            ProductResponse productsRespone;
            int totalPage; // null at first 

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
            ViewBag.TotalProduct = totalPage;
            ViewBag.Pages = (int)Math.Ceiling((totalPage / (float)pageSize));
            ViewBag.CurrentCategory = cate;
            #endregion

            return View(productsRespone.Products);
        }
        public async Task<IActionResult> Product (int? id)
        {
            #region Define HttpClient & HttpRequest
            var client = _httpClientFactory.CreateClient();
            var url = new UriBuilder(ApiUrl.PRODUCTBYID_API_URL);
            var get_product_request = new HttpRequestMessage(HttpMethod.Get, url.ToString() + id);
            #endregion

            var get_product_response = await client.SendAsync(get_product_request);

            Product products;

            if ((int)get_product_response.StatusCode == 200)
            {
                var get_product_responseData = await get_product_response.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<Product>(get_product_responseData);
                return View(products);
            }
            else
            {
                _logger.LogInformation("Product Not Found");
                return View("Error");
            }

        }


    }
}
