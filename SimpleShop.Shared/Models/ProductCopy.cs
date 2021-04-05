using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleShop.Shared.Models
{
    public class ProductCopy
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public float productPrice { get; set; }
        public string productDescription { get; set; }
        public System.DateTime uploadDate { get; set; }


        public int? categoryId { get; set; }
        public Category Category { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
        public int? ratingId { get; set; }
        public List<Rating> Ratings { get; set; } = new List<Rating>();

    }
}