using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SimpleShop.Shared.Interfaces;
using System.Security.Claims;

namespace SimpleShop.UI.ViewModels.ViewComponents
{
    public class CartNumberViewComponent : ViewComponent
    {
        private readonly IHttpClientService httpClientService;

        public CartNumberViewComponent (IHttpClientService httpClientService)
        {
            this.httpClientService = httpClientService;
        }
        public async System.Threading.Tasks.Task<IViewComponentResult> InvokeAsync ()
        {
            int orderNum = 0;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                orderNum = await httpClientService.CountUserOrderDetailAsync(await HttpContext.GetTokenAsync("access_token"), UserClaimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value);
            }
            return View(orderNum);
        }

    }
}
