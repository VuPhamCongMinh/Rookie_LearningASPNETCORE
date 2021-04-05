using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimpleShop.Shared.Models
{
    public class Rating
    {
        [Key]
        public int ratingId { get; set; }
        [Range(0, 5)]
        [Column(TypeName = "TINYINT")]
        public int rateValue { get; set; }

        public int productId { get; set; }
        public virtual Product Product { get; set; }

        public string userId { get; set; }
        public virtual IdentityUser User { get; set; }

    }
}
