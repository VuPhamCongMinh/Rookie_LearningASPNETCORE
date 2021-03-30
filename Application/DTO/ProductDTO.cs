using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class ProductDTO
    {
        public ProductDTO (int productId, string productName, float productPrice, string productDescription, string productCategory)
        {
            this.productId = productId;
            this.productName = productName;
            this.productPrice = productPrice;
            this.productDescription = productDescription;
            this.productCategory = productCategory;
        }

        public int productId { get; set; }
        public string productName { get; set; }
        public float productPrice { get; set; }
        public string productDescription { get; set; }
        public string productCategory { get; set; }
    }
}