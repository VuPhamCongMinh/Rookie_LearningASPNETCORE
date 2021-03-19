using System.ComponentModel.DataAnnotations;

namespace SimpleShop.Models
{
    public class Product
    {
        public Product(int productId, string productName, float productPrice, string productDescription)
        {
            this.productId = productId;
            this.productName = productName;
            this.productPrice = productPrice;
            this.productDescription = productDescription;
        }

        [Key]
        public int productId { get; set; }

        public string productName { get; set; }
        public float productPrice { get; set; }
        public string productDescription { get; set; }
    }
}