using Microsoft.EntityFrameworkCore;
using SimpleShop.Shared.EF;
using SimpleShop.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleShop.Shared.Services
{
    public class ProductService
    {
        private int productLength { get; set; }
        private readonly MyDBContext _context;

        public ProductService (MyDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetFilteredProducts (int pageindex, int pagesize, string searchstring, string sortorder, double? min, double? max)
        {
            var allProducts = await GetProduct();

            SearchProducts(allProducts, searchstring);
            PagingProducts(allProducts, pageindex, pagesize);
            SortProducts(allProducts, sortorder);
            FilterProducts(allProducts, min, max);

            return allProducts.ToList();
        }

        public async Task<IEnumerable<Product>> GetProduct ()
        {
            return await _context.Products.Include(p => p.Category).Include(p => p.Images).ToListAsync();
        }

        public IEnumerable<Product> GetProductDTO ()
        {
            return _context.Products.Include(p => p.Category);
        }

        void PagingProducts (IEnumerable<Product> sourceProducts, int pageindex, int pagesize)
        {
            sourceProducts = sourceProducts.Skip((pageindex - 1) * pagesize).Take(pagesize);
            //đếm số lượng sp để phân trang
            //mặc định ban đầu sẽ đếm hết
            productLength = sourceProducts.Count();
        }

        void FilterProducts (IEnumerable<Product> sourceProducts, double? min, double? max)
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

        void SortProducts (IEnumerable<Product> sourceProducts, string sortorder)
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

        public void SearchProducts (IEnumerable<Product> sourceProducts, string searchstring)
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
