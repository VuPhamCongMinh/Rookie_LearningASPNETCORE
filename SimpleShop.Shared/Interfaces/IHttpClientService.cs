using SimpleShop.Shared.Models;
using SimpleShop.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.Shared.Interfaces
{
    public interface IHttpClientService
    {
        public Task<OrderDetailResponse> GetUserOrderDetailAsync (string userId);
        public Task<int> CountUserOrderDetailAsync (string userId);
        public Task<ProductResponse> GetProductsAsync (int pageIndex = 1, int pageSize = 6, string searchString = null, string sortOrder = "asc", double? minPrice = 0, double? maxPrice = 0, int cate = -1);
        public Task<IEnumerable<Product>> GetMostOrderedProducts ();
        public Task<IEnumerable<Product>> GetNewlyAddProducts ();
        public Task<Product> GetProductByIdAsync (int id);
        public Task<Rating> PostRating (string userId, int productId, string comment, int rateValue);
        public Task<IEnumerable<RatingResponse>> GetRatingByProductId (int id);
        public Task<Order> PostCart (int productId, int quanity, bool isIncrement);
    }
}
