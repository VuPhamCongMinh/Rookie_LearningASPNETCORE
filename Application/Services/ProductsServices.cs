using System;
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
                new Product{productId = Guid.NewGuid().ToString(),productName="Product 10",productPrice = 8700,productDescription ="Product 10 description" },
                new Product{productId = Guid.NewGuid().ToString(),productName="Product 11",productPrice = 5300,productDescription ="Product 11 description" },
                new Product{productId = Guid.NewGuid().ToString(),productName="Product 12",productPrice = 6700,productDescription ="Product 12 description" },
                new Product{productId = Guid.NewGuid().ToString(),productName="Product 13",productPrice = 7300,productDescription ="Product 13 description" },
                new Product{productId = Guid.NewGuid().ToString(),productName="Product 14",productPrice = 5100,productDescription ="Product 14 description" },
                new Product{productId = Guid.NewGuid().ToString(),productName="Product 15",productPrice = 3400,productDescription ="Product 15 description" },
                          };
        private int productLength { get; set; }
        #endregion


        public IEnumerable<ProductDTO> GetProducts (int pageindex, int pagesize, string searchstring, string sortorder, double? min, double? max)
        {
            var allProducts = this.products;
            IEnumerable<Product> products = allProducts.Skip((pageindex - 1) * pagesize).Take(pagesize);
            //đếm số lượng sp để phân trang
            //mặc định ban đầu sẽ đếm hết
            productLength = allProducts.Count();

            if (searchstring != null)
            {
                products = allProducts.Where(p => p.productName.Contains(searchstring));
                //nếu user có search thì đếm những kết quả trả về hoy
                productLength = products.Count();
            }
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
        //public IEnumerable<Product> GetProducts ()
        //{

        //}
        public int GetProductCount () => productLength;
        static ProductDTO MapProductDTO (Product prod)
        {
            //map product to productDTO in order to add to productsDTO List
            ProductDTO productDTO = new ProductDTO(prod.productId, prod.productName, prod.productPrice, prod.productDescription);
            return productDTO;
        }
    }

}
