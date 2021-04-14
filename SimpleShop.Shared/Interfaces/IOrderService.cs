using Microsoft.AspNetCore.Identity;
using SimpleShop.Shared.Models;
using SimpleShop.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleShop.Shared.Interfaces
{
    public interface IOrderService
    {
        public Task<Order> PostOrderAsync (OrderCreateRequest order, string userId);
        public Task<IEnumerable<OrderDetail>> GetUserOrderDetailAsync (string userId);
        public Task<IEnumerable<Order>> GetOrders ();
        public Task<Order> GetOrder (string id);

        public int CountUserOrderAsync (string userId);
    }
}
