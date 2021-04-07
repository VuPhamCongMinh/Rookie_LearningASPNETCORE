using Newtonsoft.Json;
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
        //json ignore dùng khi ko muốn hiển thị navigation property trong đoạn json trả về
        //[JsonIgnore]
        public Product Product { get; set; }
        public string orderId { get; set; }
    }
}
