using System;
using System.Collections.Generic;
using System.Linq;
using Application.DTO;
using Application.EF;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ProductServices
    {
        #region Dummy data initialize
        private static Random rnd = new Random();
        private Product[] products = new[] {
                new Product{productId = rnd.Next(1,99),productName="Product 1",productPrice = 9700,productDescription ="Product 1 description" },
                new Product{productId = rnd.Next(1,99),productName="Product 2",productPrice = 4600,productDescription ="Product 2 description" },
                new Product{productId = rnd.Next(1,99),productName="Product 3",productPrice = 5200,productDescription ="Product 3 description" },
                new Product{productId = rnd.Next(1,99),productName="Product 4",productPrice = 9500,productDescription ="Product 4 description" },
                new Product{productId = rnd.Next(1,99),productName="Product 5",productPrice = 4700,productDescription ="Product 5 description" },
                new Product{productId = rnd.Next(1,99),productName="Product 6",productPrice = 1700,productDescription ="Product 6 description" },
                new Product{productId = rnd.Next(1,99),productName="Product 7",productPrice = 6400,productDescription ="Product 7 description" },
                new Product{productId = rnd.Next(1,99),productName="Product 8",productPrice = 2700,productDescription ="Product 8 description" },
                new Product{productId = rnd.Next(1,99),productName="Product 9",productPrice = 4300,productDescription ="Product 9 description" },
                new Product{productId = rnd.Next(1,99),productName="Product 10",productPrice = 8700,productDescription ="Product 10 description" },
                new Product{productId = rnd.Next(1,99),productName="Product 11",productPrice = 5300,productDescription ="Product 11 description" },
                new Product{productId = rnd.Next(1,99),productName="Product 12",productPrice = 6700,productDescription ="Product 12 description" },
                new Product{productId = rnd.Next(1,99),productName="Product 13",productPrice = 7300,productDescription ="Product 13 description" },
                new Product{productId = rnd.Next(1,99),productName="Product 14",productPrice = 5100,productDescription ="Product 14 description" },
                new Product{productId = rnd.Next(1,99),productName="Product 15",productPrice = 3400,productDescription ="Product 15 description" },
                          };

        private int productLength { get; set; }
        #endregion

        private readonly MyDBContext _context;

        public ProductServices (MyDBContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductDTO> GetProducts (int pageindex, int pagesize, string searchstring, string sortorder, double? min, double? max)
        {
            var allProducts = GetProduct();

            SearchProducts(ref allProducts, searchstring);
            PagingProducts(ref allProducts, pageindex, pagesize);
            SortProducts(ref allProducts, sortorder);
            FilterProducts(ref allProducts, min, max);

            return allProducts.Select(x => MapProductDTO(x)).ToList();
        }

        public IEnumerable<Product> GetProduct ()
        {
            return _context.Products.Include(p=>p.Category);
        }

        public IEnumerable<ProductDTO> GetProductDTO ()
        {
            return _context.Products.Include(p => p.Category).Select(x=>MapProductDTO(x));
        }

         void PagingProducts (ref IEnumerable<Product> sourceProducts, int pageindex, int pagesize)
        {
            sourceProducts = sourceProducts.Skip((pageindex - 1) * pagesize).Take(pagesize);
            //đếm số lượng sp để phân trang
            //mặc định ban đầu sẽ đếm hết
            productLength = sourceProducts.Count();
        }

         void FilterProducts (ref IEnumerable<Product> sourceProducts, double? min, double? max)
        {
            if (min > 0)
            {
                sourceProducts = sourceProducts.Where(p => p.productPrice > min);
            }
            if (max > 0)
            {
                sourceProducts = sourceProducts.Where(p => p.productPrice < max);
            }
        }

         void SortProducts (ref IEnumerable<Product> sourceProducts, string sortorder)
        {
            if (sortorder == "asc")
            {
                sourceProducts = sourceProducts.OrderBy(p => p.productPrice);
            }
            else if (sortorder == "desc")
            {
                sourceProducts = sourceProducts.OrderByDescending(p => p.productPrice);
            }
        }

        public void SearchProducts (ref IEnumerable<Product> sourceProducts, string searchstring)
        {
            if (searchstring != null)
            {
                sourceProducts = sourceProducts.Where(p => p.productName.Contains(searchstring));
                //nếu user có search thì đếm những kết quả trả về hoy
                productLength = sourceProducts.Count();
            }
        }

        public int GetProductCount () => productLength;
        private static ProductDTO MapProductDTO (Product prod)
        {
            //map product to productDTO in order to add to productsDTO List
            ProductDTO productDTO = new ProductDTO(prod.productId, prod.productName, prod.productPrice, prod.productDescription, prod.Category.categoryName);
            return productDTO;
        }
    }

}
