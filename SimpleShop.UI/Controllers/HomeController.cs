using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleShop.Shared.Interfaces;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SimpleShop.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientService httpClient;

        public HomeController (IHttpClientService httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IActionResult> Index (int pageIndex = 1, int pageSize = 6, string searchString = null, string sortOrder = "asc", double? minPrice = 0, double? maxPrice = 0, int cate = -1)
        {
            var productsRespone = await httpClient.GetProductsAsync(pageIndex, pageSize, searchString, sortOrder, minPrice, maxPrice, cate);

            int totalPage = productsRespone.Count;
            #region Define ViewBag 
            ViewBag.MinPrice = minPrice != 0 ? minPrice : null;
            ViewBag.MaxPrice = maxPrice != 0 ? maxPrice : null;
            ViewBag.SortOrder = sortOrder == "asc" ? 0 : 1;
            ViewBag.SearchString = !string.IsNullOrEmpty(searchString) ? searchString : null;
            ViewBag.TotalProduct = totalPage;
            ViewBag.Pages = (int)Math.Ceiling((totalPage / (float)pageSize));
            ViewBag.CurrentCategory = cate;
            #endregion

            return View(productsRespone.Products);
        }
        public async Task<IActionResult> Product (int id)
        {
            var product = await httpClient.GetProductByIdAsync(id);

            if (product != null)
            {
                return View(product);
            }
            else
            {
                return View("Error");
            }

        }

        public async Task<IActionResult> Review (IFormCollection fc)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {

                #region init param from formcollection
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                string message = fc["message"];
                string rate = fc["rate"];
                int productId = int.Parse(fc["product_id"]);
                #endregion
                if (rate == null || message == null)
                {
                    return View("Error");
                }
                var rating = await httpClient.PostRating(userId, productId, message, int.Parse(rate));

                if (rating != null)
                {
                    return RedirectToAction("Product", new { id = productId });
                }
                else
                {
                    return View("Error");
                }
            }
            else
            {
                return RedirectToAction("SignIn", "Account");
            }
        }


    }
}
