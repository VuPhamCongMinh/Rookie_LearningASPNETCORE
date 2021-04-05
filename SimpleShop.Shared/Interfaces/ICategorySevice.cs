using SimpleShop.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleShop.Shared.Interfaces
{
    public interface ICategorySevice
    {
        public Task<IEnumerable<Category>> GetCategories ();
        public Task<Category> GetCategoryById (int id);
    }
}