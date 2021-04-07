using Microsoft.AspNetCore.Authentication;
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
                var userOrder = await httpClientService.GetUserOrderDetailAsync(await HttpContext.GetTokenAsync("access_token"), User.FindFirst(ClaimTypes.NameIdentifier).Value);
                return View(userOrder);
            }
            return View(null);
        }
    }
}
