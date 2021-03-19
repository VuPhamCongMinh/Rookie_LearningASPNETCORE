using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class ProductDTO
    {
        public ProductDTO (string productId, string productName, float productPrice, string productDescription)
        {
            this.productId = productId;
            this.productName = productName;
            this.productPrice = productPrice;
            this.productDescription = productDescription;
        }

        public string productId { get; set; }

        public string productName { get; set; }
        public float productPrice { get; set; }
        public string productDescription { get; set; }
    }
}