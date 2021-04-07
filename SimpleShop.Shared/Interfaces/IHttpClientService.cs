﻿using SimpleShop.Shared.Models;
using SimpleShop.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.Shared.Interfaces
{
    public interface IHttpClientService
    {
        public Task<OrderResponse> GetUserOrderAsync (string userToken, string userId);
        public Task<int> CountUserOrderAsync (string userToken, string userId);
        public Task<ProductResponse> GetProductsAsync (int pageIndex = 1, int pageSize = 6, string searchString = null, string sortOrder = "asc", double? minPrice = 0, double? maxPrice = 0, int cate = -1);
        public Task<Product> GetProductByIdAsync (int id);
    }
}
