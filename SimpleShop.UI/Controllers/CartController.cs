using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleShop.Shared.Interfaces;
using SimpleShop.Shared.ViewModels;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SimpleShop.UI.Controllers
{
    public class CartController : Controller
    {
        private readonly IHttpClientService httpClientService;

        public CartController (IHttpClientService httpClientService)
        {
            this.httpClientService = httpClientService;
        }
        public async Task<ActionResult> Index ()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var userOrder = await httpClientService.GetUserOrderDetailAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                return View(userOrder);
            }
            return View(null);
        }
        [Authorize]
        public async Task<ActionResult> AddCart (int productId, int quantity , bool isIncrement = true)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                try
                {
                    await httpClientService.PostCart(productId, quantity, isIncrement);
                    return RedirectToAction("Index");
                }
                catch (System.Exception e)
                {
                    throw;
                }
            }
            return View("Error");
        }
    }
}
