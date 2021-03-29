using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class ImageStorage
    {
        [Key]
        public int imageStorageId { get; set; }
        [MaxLength(255)]
        public string imageUrl { get; set; }
    }
}
