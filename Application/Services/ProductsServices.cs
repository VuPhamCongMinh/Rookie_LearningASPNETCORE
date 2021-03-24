using System;
using System.Collections.Generic;
using Application.DTO;
using Domain.Entities;

namespace Application.Services
{
    public class ProductServices
    {
        public IEnumerable<ProductDTO> GetProducts ()
        {
            Product[] products = new[] {
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

            return mapProductDTO(products);
        }


        static IEnumerable<ProductDTO> mapProductDTO (Product[] products)
        {
            List<ProductDTO> productsDTO = new List<ProductDTO>();
            foreach (var prod in products)
            {
                //map product to productDTO in order to add to productsDTO List
                ProductDTO productDTO = new ProductDTO(prod.productId, prod.productName, prod.productPrice, prod.productDescription);

                productsDTO.Add(productDTO);
            }
            return productsDTO;
        }
    }

}
