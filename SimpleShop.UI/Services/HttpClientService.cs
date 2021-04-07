﻿using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SimpleShop.Shared.Constant;
using SimpleShop.Shared.Interfaces;
using SimpleShop.Shared.Models;
using SimpleShop.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SimpleShop.UI.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient client;

        public HttpClientService (IHttpClientFactory httpClient)
        {
            this.client = httpClient.CreateClient();
        }
        public async Task<int> CountUserOrderDetailAsync (string userToken, string userId)
        {
            #region Define HttpClient & HttpRequest
            var url = new UriBuilder(ApiUrl.COUNT_ORDER_API_URL)
            {
                Query = $"userid={userId}"
            };
            // 2 dòng dưới dùng khi muốn chèn access token vào httpclient đề lấy api đã dc bảo mật
            var cartNumber_request = new HttpRequestMessage(HttpMethod.Get, url.ToString());
            cartNumber_request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", userToken);
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
            var get_product_request = new HttpRequestMessage(HttpMethod.Get, url.ToString() + id);
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
            var url = new UriBuilder(ApiUrl.PRODUCTS_API_URL)
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

        public async Task<IEnumerable<OrderDetail>> GetUserOrderDetailAsync (string userToken, string userId)
        {
            #region Define HttpClient & HttpRequest
            var url = new UriBuilder(ApiUrl.GET_ORDER_API_URL)
            {
                Query = $"userid={userId}"
            };
            var userOrder_request = new HttpRequestMessage(HttpMethod.Get, url.ToString());
            userOrder_request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", userToken);
            #endregion
            var get_userOrder_response = await client.SendAsync(userOrder_request);

            if (get_userOrder_response.IsSuccessStatusCode)
            {
                var get_cartNumber_responseData = await get_userOrder_response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<OrderDetail>>(get_cartNumber_responseData);
            }
            else
            {
                return null;
            }
        }
    }
}
