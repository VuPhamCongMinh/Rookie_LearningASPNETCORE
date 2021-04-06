using Microsoft.AspNetCore.Identity;
using SimpleShop.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimpleShop.Shared.Models
{
    public class Order : Auditable
    {
        [Key]
        public string orderId { get; set; }

        [ForeignKey("user")]
        public string userId { get; set; }
        public IdentityUser user { get; set; }
        public ICollection<OrderDetail> orderDetails { get; set; }
       }
}
