using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimpleShop.Shared.Constant;
using SimpleShop.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SimpleShop.UI.ViewModels.ViewComponents
{
    public class CartNumberViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CartNumberViewComponent (IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async System.Threading.Tasks.Task<IViewComponentResult> InvokeAsync ()
        {

            #region Define HttpClient & HttpRequest
            var client = _httpClientFactory.CreateClient();
            var userId = UserClaimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value;
            var url = new UriBuilder(ApiUrl.USERORDER_API_URL)
            {
                Query = $"userid={userId}"
            };
            var cartNumber_request = new HttpRequestMessage(HttpMethod.Get, url.ToString());
            // 2 dòng dưới dùng khi muốn chèn access token vào httpclient đề lấy api đã dc bảo mật
            var access = await HttpContext.GetTokenAsync("access_token");
            cartNumber_request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", access);
            #endregion
            var get_cartNumber_response = await client.SendAsync(cartNumber_request);

            OrderResponse userOrder;

            if (get_cartNumber_response.IsSuccessStatusCode)
            {
                var get_cartNumber_responseData = await get_cartNumber_response.Content.ReadAsStringAsync();
                userOrder = JsonConvert.DeserializeObject<OrderResponse>(get_cartNumber_responseData);
            }
            else
            {
                userOrder = null;
            }

            return View(userOrder);
        }

    }
}
