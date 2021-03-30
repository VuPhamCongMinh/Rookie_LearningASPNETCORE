using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Product
    {
        [Key]
        public int productId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string productName { get; set; }
        public float productPrice { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string productDescription { get; set; }
        public System.DateTime uploadDate { get; set; }


        public int? categoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Image> Images { get; set; }

    }
}