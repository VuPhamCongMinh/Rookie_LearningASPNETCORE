using SimpleShop.Shared.Models;
using SimpleShop.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleShop.Shared.Interfaces
{
    public interface IProductService
    {
        public IEnumerable<Product> GetFilteredProducts (int pageindex, int pagesize, string searchstring, string sortorder, double? min, double? max, int cate);

        public Task<IEnumerable<Product>> GetProducts();

        public Task<Product> GetProductByID (int id);
        public int GetProductCount ();
        public Task<Product> PostProduct (ProductPostRequest product);
        public Task<Product> PutProduct (int id, ProductPostRequest product);
        public Task<int> DeleteProduct (int id);

    }
}