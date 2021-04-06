using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleShop.Shared.Models
{
    public class Order
    {
        [Key]
        public string orderId { get; set; }
        public IdentityUser user { get; set; }
        public ICollection<OrderDetail> CartDetails { get; set; }
    }
}
