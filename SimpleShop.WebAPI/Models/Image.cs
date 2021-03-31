using System.ComponentModel.DataAnnotations;

namespace SimpleShop.WebAPI.Entities
{
    public class Image
    {
        [Key]
        public int imageId { get; set; }
        public string imageUrl { get; set; }
        public int productId { get; set; }
    }
}
