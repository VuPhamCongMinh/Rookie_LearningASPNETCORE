using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Image
    {
        [Key]
        public int imageId { get; set; }
        public string imageUrl { get; set; }
        public int productId { get; set; }
        public Product Product { get; set; }
    }
}
