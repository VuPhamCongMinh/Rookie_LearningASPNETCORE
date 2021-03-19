using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Application.Services
{
    public class ProductServices
    {
        public IEnumerable<Product> GetProducts()
        {
            return new List<Product> {
                new Product( int.Parse(Guid.NewGuid().ToString()),"Product 1",9500,"Product 1 description"),
                new Product( int.Parse(Guid.NewGuid().ToString()),"Product 2",5900,"Product 2 description"),
                new Product( int.Parse(Guid.NewGuid().ToString()),"Product 3",5400,"Product 3 description"),
                new Product( int.Parse(Guid.NewGuid().ToString()),"Product 4",6500,"Product 4 description"),
                new Product( int.Parse(Guid.NewGuid().ToString()),"Product 5",1500,"Product 5 description"),
            };
        }
    }

}
