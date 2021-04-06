﻿using Microsoft.AspNetCore.Identity;
using SimpleShop.Shared.Models;
using SimpleShop.Shared.ViewModels;
using System.Threading.Tasks;

namespace SimpleShop.Shared.Interfaces
{
    public interface IOrderService
    {
        public Task<Order> PostOrder (OrderCreateRequest order, string userId);
    }
}
