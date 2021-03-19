using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Variation
    {
        [Key]
        public int variationId { get; set; }
        public int productId { get; set; }
        public string variationName { get; set; }
    }
}
