using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
            productDescription = "Test Product Request Desc",
            Images = new List<Image>()
            {
                new Image{imageUrl = "picture1.jpg" },
                new Image{imageUrl = "picture2.jpg"},
                new Image{imageUrl = "picture3.jpg"},
            }
        };

        public static Category NewCategory () => new Category
        {
            categoryName = "Test Category"
        };
        public static IdentityUser NewUser () => new IdentityUser
        {
            UserName = "Test User"
        };
        public static Rating NewRating () => new Rating
        {
            rateValue = 5,
            comment = "Test comment",
            createdDate = DateTime.Now,
            updatedDate = DateTime.Now,

        };
        public static Category CategoryAfterPut () => new Category
        {
            categoryName = "Category Changed"
        };
        public static Category CategoryPutRequest () => new Category
        {
            categoryName = "Category Changed",
        };


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

        public static ProductPostRequest NewProductPutRequest () => new ProductPostRequest
        {
            productName = "Name Changed",
            productPrice = 400,
            productDescription = "Desc Changed",
            ImageFiles = new List<IFormFile>()
            {
                new FormFile(null,1,1,"picture1.jpg","picture1"),
                new FormFile(null,2,3,"picture3.jpg","picture2"),
                new FormFile(null,2,3,"picture2.jpg","picture3"),
            }
        };

        public static Product ProductAfterPut () => new Product
        {
            productId = 10,
            productName = "Name Changed",
            productPrice = 400,
            productDescription = "Desc Changed",
            Images = new List<Image>()
            {
                new Image{imageUrl = "picture3.jpg" },
                new Image{imageUrl = "picture2.jpg"},
                new Image{imageUrl = "picture1.jpg"},
            }
            ,
            Category = NewCategory()
        };


    }
}
