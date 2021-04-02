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
        private IEnumerable<Product> allProduct { get; set; }

        public ProductService (MyDBContext context)
        {
            _context = context;
            allProduct = _context.Products.Include(p => p.Category).Include(p => p.Images).ToList();
        }

        public IEnumerable<Product> GetFilteredProducts (int pageindex, int pagesize, string searchstring, string sortorder, double? min, double? max)
        {
            var allProducts = allProduct;
            productLength = allProducts.Count();

            SearchProducts(ref allProducts, searchstring);
            SortProducts(ref allProducts, sortorder);
            FilterProducts(ref allProducts, min, max);
            PagingProducts(ref allProducts, pageindex, pagesize, searchstring);

            return allProducts.ToList();
        }

        public async Task<IEnumerable<Product>> GetProduct ()
        {
            return await _context.Products.Include(p => p.Category).Include(p => p.Images).ToListAsync();
        }

        void PagingProducts (ref IEnumerable<Product> sourceProducts, int pageindex, int pagesize, string searchstring)
        {
            sourceProducts = sourceProducts.Skip((pageindex - 1) * pagesize).Take(pagesize);
        }

        void FilterProducts (ref IEnumerable<Product> sourceProducts, double? min, double? max)
        {

            if (min > 0)
            {
                sourceProducts = sourceProducts.Where(p => p.productPrice >= min);
            }
            if (max > 0)
            {
                sourceProducts = sourceProducts.Where(p => p.productPrice <= max);
            }
            productLength = sourceProducts.Count();
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
                sourceProducts = sourceProducts.Where(p => p.productName.ToLower().Contains(searchstring.ToLower()));
                //nếu user có search thì đếm những kết quả trả về hoy
                productLength = sourceProducts.Count();
            }
        }



        public int GetProductCount () => productLength;
    }
}
