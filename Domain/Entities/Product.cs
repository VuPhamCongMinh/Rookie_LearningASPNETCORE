using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Product
    {
        [Key]
        public string productId { get; set; }

        public string productName { get; set; }
        public float productPrice { get; set; }
        public string productDescription { get; set; }
    }
}