using SimpleShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleShop.Shared.ViewModels
{
    public class ProductResponse
    {
        public IEnumerable<Product> Products { get; set; }
        public int Count { get;  set; }
    }
}
