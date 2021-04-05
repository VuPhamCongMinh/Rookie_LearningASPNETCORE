using Microsoft.EntityFrameworkCore;
using SimpleShop.Shared.Interfaces;
using SimpleShop.Shared.EF;
using SimpleShop.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SimpleShop.Shared.ViewModels;

namespace SimpleShop.API.Services
{
    public class CategoryService : ICategorySevice
    {

        private readonly MyDBContext _context;
        private readonly IMapper mapper;

        public CategoryService (MyDBContext context,IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Category>> GetCategories ()
        {

            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById (int id)
        {
            return await _context.Categories.FindAsync(id);
        }
    }
}
