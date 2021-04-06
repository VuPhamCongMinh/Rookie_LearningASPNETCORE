using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimpleShop.Shared.Models
{
    public class OrderDetail
    {
        [Key]
        public int orderDetailId { get; set; }
        public int quantity { get; set; }


        [ForeignKey("Product")]
        public int productId { get; set; }
        public Product Product { get; set; }


        [ForeignKey("Order")]
        public string orderId { get; set; }
        public Order Order { get; set; }
    }
}
