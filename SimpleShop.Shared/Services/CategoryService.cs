using SimpleShop.Shared.EF;
using SimpleShop.Shared.Models;
using SimpleShop.Shared.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace SimpleShop.Shared.Services
{
    public class CategoryService
    {

        private readonly MyDBContext _context;

        public CategoryService (MyDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetCategories ()
        {
            return _context.Categories.ToList();
        }



    }
}
