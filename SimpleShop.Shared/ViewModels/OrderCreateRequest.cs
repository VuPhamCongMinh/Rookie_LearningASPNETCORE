using SimpleShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleShop.Shared.ViewModels
{
    public class OrderCreateRequest
    {
        public int productId { get; set; }
        public int quantity { get; set; }
    }
}
