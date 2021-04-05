using Microsoft.AspNetCore.Http;
using SimpleShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimpleShop.Shared.ViewModels
{
    public class ProductPostRequest
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public float productPrice { get; set; }
        public string productDescription { get; set; }
        public System.DateTime uploadDate { get; set; }
        public int? categoryId { get; set; }
        public List<IFormFile> Images { get; set; }
        public int? ratingId { get; set; }
    }
}
