using Microsoft.AspNetCore.Http;
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
        public static Product NewProduct ()
        {
            var id = new Random().Next(0, 20);


            return new Product
            {
                productId = id,
                productName = "Test Product Request Name",
                productPrice = 200,
                productDescription = "Test Product Request Desc",
                Images = new List<Image>()
                {
                    new Image{imageUrl = "picture1.jpg",productId = id },
                    new Image{imageUrl = "picture2.jpg",productId = id },
                    new Image{imageUrl = "picture3.jpg",productId = id },
                }
            };
        }

        public static ProductPostRequest NewProductPostRequest () => new ProductPostRequest
        {
            productName = "Test Product Request Name",
            productPrice = 200,
            productDescription = "Test Product Request Desc",
            ImageFiles = new List<IFormFile>()
            {
                new FormFile(null,1,1,"picture1.jpg","picture1"),
                new FormFile(null,2,3,"picture3.jpg","picture2"),
                new FormFile(null,2,3,"picture2.jpg","picture3"),
            }
        };

        public static Category NewCategory () => new Category
        {
            categoryName = "Test Category",
        };


    }
}
