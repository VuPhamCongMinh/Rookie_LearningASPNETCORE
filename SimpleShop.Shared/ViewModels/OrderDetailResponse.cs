using SimpleShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleShop.Shared.ViewModels
{
    public class OrderDetailResponse
    {
        public IEnumerable<OrderDetail> orderDetails { get; set; }
        public double totalPrice { get; set; }
    }
}
