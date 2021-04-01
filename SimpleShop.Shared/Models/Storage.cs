using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleShop.Shared.Models
{
    public class Storage
    {
        [Key]
        public int storageId { get; set; }
        public int productId { get; set; }
        public int variationId { get; set; }
        public int quantity { get; set; }
    }
}
