﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleShop.WebAPI.EF;
using SimpleShop.WebAPI.Entities;

namespace Application.Services
{
    public class ProductServices
    {
        private int productLength { get; set; }
        private readonly MyDBContext _context;

        public ProductServices (MyDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetFilteredProducts (int pageindex, int pagesize, string searchstring, string sortorder, double? min, double? max)
        {
            var allProducts = await GetProduct();

            SearchProducts(ref allProducts, searchstring);
            PagingProducts(ref allProducts, pageindex, pagesize);
            SortProducts(ref allProducts, sortorder);
            FilterProducts(ref allProducts, min, max);

            return allProducts.ToList();
        }

        public async Task<IEnumerable<Product>> GetProduct ()
        {
            return await _context.Products.Include(p => p.Category).Include(p=>p.Images).ToListAsync();
        }

        public IEnumerable<Product> GetProductDTO ()
        {
            return _context.Products.Include(p => p.Category);
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
    }

}
