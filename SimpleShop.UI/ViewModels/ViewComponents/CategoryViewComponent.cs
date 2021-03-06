using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimpleShop.Shared.Models;
using SimpleShop.UI.Constant;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace SimpleShop.ViewModels.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryViewComponent (IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async System.Threading.Tasks.Task<IViewComponentResult> InvokeAsync ()
        {
            var client = _httpClientFactory.CreateClient();
            var category_request = new HttpRequestMessage(HttpMethod.Get, ApiUrl.CATEGORIES_API_URL);


            try
            {
                var get_categories_response = await client.SendAsync(category_request);
                IEnumerable<Category> categoryResponse;
                if (get_categories_response.IsSuccessStatusCode)
                {
                    var get_categories_responseData = await get_categories_response.Content.ReadAsStringAsync();
                    categoryResponse = JsonConvert.DeserializeObject<IEnumerable<Category>>(get_categories_responseData);
                }
                else
                {
                    categoryResponse = null;
                }
                return View(categoryResponse);
            }
            catch (System.Exception)
            {
                return View(Enumerable.Empty<Category>());
            }
        }


    }
}
