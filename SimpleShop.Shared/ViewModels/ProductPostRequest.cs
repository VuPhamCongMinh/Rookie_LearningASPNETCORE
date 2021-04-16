using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace SimpleShop.Shared.ViewModels
{
    public class ProductPostRequest
    {
        public string productName { get; set; }
        public float productPrice { get; set; }
        public string productDescription { get; set; }
        public int? categoryId { get; set; }
        public List<IFormFile> ImageFiles { get; set; }
    }
}
