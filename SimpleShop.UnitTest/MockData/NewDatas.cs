using SimpleShop.Shared.Models;
using SimpleShop.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.UnitTest.MockData
{
    public static class NewDatas
    {
        public static Product NewProduct () => new Product
        {
            productName = "Test Product Request Name",
            productPrice = 200,
            productDescription = "Test Product Request Desc"
        };

        public static ProductPostRequest NewProductPostRequest () => new ProductPostRequest
        {
            productName = "Test Product Request Name",
            productPrice = 200,
            productDescription = "Test Product Request Desc"
        };

        public static Category NewCategory () => new Category
        {
            categoryName = "Test Category",
        };

     
    }
}
