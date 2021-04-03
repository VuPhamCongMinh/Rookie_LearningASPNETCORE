using SimpleShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleShop.Shared.ViewModels
{
    public class CategoryResponse
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}
