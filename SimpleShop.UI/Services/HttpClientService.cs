using Newtonsoft.Json;
using SimpleShop.Shared.Constant;
using SimpleShop.Shared.Interfaces;
using SimpleShop.Shared.Models;
using SimpleShop.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.UI.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient client;

        public HttpClientService (HttpClient httpClient)
        {
            this.client = httpClient;
        }
        public async Task<int> CountUserOrderDetailAsync (string userId)
        {
            #region Define HttpClient & HttpRequest
            var url = new UriBuilder(ApiUrl.COUNT_ORDER_API_URL)
            {
                Query = $"userid={userId}"
            };
            var cartNumber_request = new HttpRequestMessage(HttpMethod.Get, url.ToString());
            #endregion
            var get_cartNumber_response = await client.SendAsync(cartNumber_request);

            int userOrder;

            if (get_cartNumber_response.IsSuccessStatusCode)
            {
                var get_cartNumber_responseData = await get_cartNumber_response.Content.ReadAsStringAsync();
                userOrder = int.Parse(get_cartNumber_responseData);
            }
            else
            {
                userOrder = 0;
            }

            return userOrder;
        }

        public async Task<Product> GetProductByIdAsync (int id)
        {
            #region Define HttpClient & HttpRequest
            var url = new UriBuilder(ApiUrl.PRODUCTS_API_URL);
            var get_product_request = new HttpRequestMessage(HttpMethod.Get, $"{url}/{id}");
            #endregion

            var get_product_response = await client.SendAsync(get_product_request);

            Product products;

            if ((int)get_product_response.StatusCode == 200)
            {
                var get_product_responseData = await get_product_response.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<Product>(get_product_responseData);
                return products;
            }
            else
            {
                return null;
            }
        }

        public async Task<ProductResponse> GetProductsAsync (int pageIndex, int pageSize, string searchString, string sortOrder, double? minPrice, double? maxPrice, int cate)
        {
            #region Define HttpClient & HttpRequest
            var url = new UriBuilder(ApiUrl.FILTERED_PRODUCTS_API_URL)
            {
                Query = $"pageindex={pageIndex}&pagesize={pageSize}&searchstring={searchString}&sortorder={sortOrder}&minprice={minPrice}&maxprice={maxPrice}&cate={cate}"
            };
            var get_product_request = new HttpRequestMessage(HttpMethod.Get, url.ToString());
            #endregion

            var get_product_response = await client.SendAsync(get_product_request);

            if (get_product_response.IsSuccessStatusCode)
            {
                var get_product_responseData = await get_product_response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProductResponse>(get_product_responseData);
            }
            else
            {
                return null;
            }
        }

        public async Task<OrderDetailResponse> GetUserOrderDetailAsync (string userId)
        {
            #region Define HttpClient & HttpRequest
            var url = new UriBuilder(ApiUrl.GET_ORDER_API_URL)
            {
                Query = $"userid={userId}"
            };
            var userOrder_request = new HttpRequestMessage(HttpMethod.Get, url.ToString());
            #endregion
            var get_userOrder_response = await client.SendAsync(userOrder_request);

            if (get_userOrder_response.IsSuccessStatusCode)
            {
                var get_cartNumber_responseData = await get_userOrder_response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<OrderDetailResponse>(get_cartNumber_responseData);
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<RatingResponse>> GetRatingByProductId (int id)
        {
            #region Define HttpClient & HttpRequest
            var url = new UriBuilder(ApiUrl.RATING_API_URL);
            var productRating_request = new HttpRequestMessage(HttpMethod.Get, $"{url}/{id}");
            #endregion
            var get_productRating_response = await client.SendAsync(productRating_request);

            if (get_productRating_response.IsSuccessStatusCode)
            {
                var get_productRating_responseData = await get_productRating_response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<RatingResponse>>(get_productRating_responseData);
            }
            else
            {
                return null;
            }
        }

        public async Task<Rating> PostRating (string userId, int productId, string comment, int rateValue)
        {
            #region Define HttpClient & HttpRequest
            var url = new UriBuilder(ApiUrl.RATING_API_URL);
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("userId", userId),
                new KeyValuePair<string, string>("productId", productId.ToString()),
                new KeyValuePair<string, string>("rateValue", rateValue.ToString()),
                new KeyValuePair<string, string>("comment", comment),
            });
            #endregion

            var get_userRating_request = await client.PostAsync(url.ToString(), content);
            if (get_userRating_request.IsSuccessStatusCode)
            {
                var get_userRating_responseData = await get_userRating_request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Rating>(get_userRating_responseData);
            }
            else
            {
                return null;
            }
        }

        public async Task<Order> PostCart (int productId, int quanity, bool isIncrement)
        {
            #region Define HttpClient & HttpRequest
            var url = new UriBuilder(ApiUrl.ORDERS_API_URL);
            var orderRequest = new OrderCreateRequest { productId = productId };
            orderRequest.quantity = isIncrement ? quanity : -quanity;
            #endregion

            var get_cart_request = await client.PostAsync(url.ToString(), JsonContent.Create(orderRequest));
            if (get_cart_request.IsSuccessStatusCode)
            {
                var get_userCart_responseData = await get_cart_request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Order>(get_userCart_responseData);
            }
            else
            {
                return null;
            }
        }
    }
}
