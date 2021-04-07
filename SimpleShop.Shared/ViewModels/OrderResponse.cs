using SimpleShop.Shared.Interfaces;
using SimpleShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleShop.Shared.ViewModels
{
    public class OrderResponse : Auditable
    {
        public string orderId { get; set; }
        public string userId { get; set; }
        public ICollection<OrderDetail> orderDetails { get; set; }
    }
}
