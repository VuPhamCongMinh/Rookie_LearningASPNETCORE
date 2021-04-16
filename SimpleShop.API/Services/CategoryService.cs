﻿using Microsoft.EntityFrameworkCore;
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

        public CategoryService (MyDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategories ()
        {

            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById (int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Category> PostCategory (Category cate)
        {
            try
            {
                await _context.Categories.AddAsync(cate);
                await _context.SaveChangesAsync();
                return cate;
            }
            catch (System.Exception e)
            {

                return null;
            }
        }

        public async Task<Category> PutCategory (int id, Category cate)
        {
            var cateInDb = await _context.Categories.FindAsync(id);
            if (cateInDb is null)
            {
                return null;
            }

            try
            {
                cateInDb.categoryName = cate.categoryName;
                await _context.SaveChangesAsync();
                return cateInDb;
            }
            catch (System.Exception e)
            {
                return null;
            }

        }
    }
}