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
                new Product( int.Parse(Guid.NewGuid().ToString()),"Product 1",9500,"Product 1 description"),
                new Product( int.Parse(Guid.NewGuid().ToString()),"Product 2",5900,"Product 2 description"),
                new Product( int.Parse(Guid.NewGuid().ToString()),"Product 3",5400,"Product 3 description"),
                new Product( int.Parse(Guid.NewGuid().ToString()),"Product 4",6500,"Product 4 description"),
                new Product( int.Parse(Guid.NewGuid().ToString()),"Product 5",1500,"Product 5 description"),
            };

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
