using SimpleShop.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleShop.Shared.Models
{
    public class Product : Auditable
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



        public int? categoryId { get; set; }
        public Category Category { get; set; }


        public int? ratingId { get; set; }
        public List<Rating> Ratings { get; set; } = new List<Rating>();
        public List<Image> Images { get; set; } = new List<Image>();
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }
    }
}