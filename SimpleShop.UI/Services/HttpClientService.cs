using Newtonsoft.Json;
using SimpleShop.Shared.Interfaces;
using SimpleShop.Shared.Models;
using SimpleShop.Shared.ViewModels;
using SimpleShop.UI.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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

            if ((int)get_cartNumber_response.StatusCode == 200)
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

            try
            {
                var get_product_response = await client.SendAsync(get_product_request);
                if ((int)get_product_response.StatusCode == 200)
                {
                    var get_product_responseData = await get_product_response.Content.ReadAsStringAsync();
                    var products = JsonConvert.DeserializeObject<ProductResponse>(get_product_responseData);
                    return products;
                }
                else
                {
                    return new ProductResponse { Products = new List<Product>(), Count = 0 };
                }
            }
            catch (Exception e)
            {
                return new ProductResponse { Products = new List<Product>(), Count = 0 };
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

            if ((int)get_userOrder_response.StatusCode == 200)
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

            try
            {
                var get_productRating_response = await client.SendAsync(productRating_request);

                if ((int)get_productRating_response.StatusCode == 200)
                {
                    var get_productRating_responseData = await get_productRating_response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<RatingResponse>>(get_productRating_responseData);
                }
                else
                {
                    return Enumerable.Empty<RatingResponse>();
                }
            }
            catch (Exception e)
            {

                return Enumerable.Empty<RatingResponse>();
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
            if ((int)get_userRating_request.StatusCode == 201)
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
            if ((int)get_cart_request.StatusCode == 200)
            {
                var get_userCart_responseData = await get_cart_request.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Order>(get_userCart_responseData);
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Product>> GetMostOrderedProducts ()
        {
            var products_request = new HttpRequestMessage(HttpMethod.Get, ApiUrl.MOST_ORDERED_PRODUCTS_API_URL);
            try
            {
                var get_products_response = await client.SendAsync(products_request);
                if ((int)get_products_response.StatusCode == 200)
                {
                    var get_products_responseData = await get_products_response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<Product>>(get_products_responseData);
                }
                else
                {
                    return Enumerable.Empty<Product>();
                }

            }
            catch (Exception e)
            {
                return Enumerable.Empty<Product>();
            }
        }

        public async Task<IEnumerable<Product>> GetNewlyAddProducts ()
        {
            var products_request = new HttpRequestMessage(HttpMethod.Get, ApiUrl.NEWLY_ADDED_PRODUCTS_API_URL);
            try
            {
                var get_products_response = await client.SendAsync(products_request);
                if ((int)get_products_response.StatusCode == 200)
                {
                    var get_products_responseData = await get_products_response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<Product>>(get_products_responseData);
                }
                else
                {
                    return Enumerable.Empty<Product>();
                }

            }
            catch (Exception e)
            {
                return Enumerable.Empty<Product>();
            }
        }
    }
}
