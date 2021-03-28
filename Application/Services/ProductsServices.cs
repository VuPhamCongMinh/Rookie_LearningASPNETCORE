﻿using System;
using System.Collections.Generic;
using System.Linq;
using Application.DTO;
using Domain.Entities;

namespace Application.Services
{
    public class ProductServices
    {

        #region Dummy data initialize
        private Product[] products = new[] {
                new Product{productId = Guid.NewGuid().ToString(),productName="Product 1",productPrice = 9700,productDescription ="Product 1 description" },
                new Product{productId = Guid.NewGuid().ToString(),productName="Product 2",productPrice = 4600,productDescription ="Product 2 description" },
                new Product{productId = Guid.NewGuid().ToString(),productName="Product 3",productPrice = 5200,productDescription ="Product 3 description" },
                new Product{productId = Guid.NewGuid().ToString(),productName="Product 4",productPrice = 9500,productDescription ="Product 4 description" },
                new Product{productId = Guid.NewGuid().ToString(),productName="Product 5",productPrice = 4700,productDescription ="Product 5 description" },
                new Product{productId = Guid.NewGuid().ToString(),productName="Product 6",productPrice = 1700,productDescription ="Product 6 description" },
                new Product{productId = Guid.NewGuid().ToString(),productName="Product 7",productPrice = 6400,productDescription ="Product 7 description" },
                new Product{productId = Guid.NewGuid().ToString(),productName="Product 8",productPrice = 2700,productDescription ="Product 8 description" },
                new Product{productId = Guid.NewGuid().ToString(),productName="Product 9",productPrice = 4300,productDescription ="Product 9 description" },
                          };
        #endregion


        public IEnumerable<ProductDTO> GetProducts (string sortorder, double? min, double? max)
        {
            var allProducts = this.products;
            IEnumerable<Product> products = allProducts;
            //this.products.Select(x => MapProductDTO(x));
            if (sortorder == "asc")
            {
                products = products.OrderBy(p => p.productPrice);
            }
            else if (sortorder == "desc")
            {
                products = products.OrderByDescending(p => p.productPrice);
            }
            if (min > 0)
            {
                products = products.Where(p => p.productPrice > min);
            }
            if (max > 0)
            {
                products = products.Where(p => p.productPrice < max);
            }
            return products.Select(x => MapProductDTO(x));
        }

        static ProductDTO MapProductDTO (Product prod)
        {
            //map product to productDTO in order to add to productsDTO List
            ProductDTO productDTO = new ProductDTO(prod.productId, prod.productName, prod.productPrice, prod.productDescription);
            return productDTO;
        }
    }

}
