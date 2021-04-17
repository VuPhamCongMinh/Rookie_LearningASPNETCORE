﻿using Microsoft.EntityFrameworkCore;
using SimpleShop.Shared.Interfaces;
using SimpleShop.Shared.EF;
using SimpleShop.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleShop.Shared.ViewModels;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using System;

namespace SimpleShop.API.Services
{
    public class ProductService : IProductService
    {
        private int productLength { get; set; }
        private readonly MyDBContext _context;
        private readonly IFilesService _filesService;
        private readonly IMapper _mapper;

        private IEnumerable<Product> allProduct { get; set; }

        public ProductService (MyDBContext context, IFilesService filesService, IMapper mapper)
        {
            _context = context;
            _filesService = filesService;
            _mapper = mapper;
            allProduct = _context.Products.Include(p => p.Category).Include(p => p.Images).ToList();
        }

        public IEnumerable<Product> GetFilteredProducts (int pageIndex, int pageSize, string searchString, string sortOrder, double? minPrice, double? maxPrice, int cate)
        {
            var allProducts = allProduct;
            productLength = allProducts.Count();

            CategorizeProducts(ref allProducts, cate);
            SearchProducts(ref allProducts, searchString);
            SortProducts(ref allProducts, sortOrder);
            FilterProducts(ref allProducts, minPrice, maxPrice);
            PagingProducts(ref allProducts, pageIndex, pageSize);

            return allProducts.ToList();
        }

        public async Task<IEnumerable<Product>> GetProduct ()
        {
            return await _context.Products.Include(p => p.Category).Include(p => p.Images).AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetProductByID (int id)
        {
            return await _context.Products.Include(p => p.Category)
                .Include(p => p.Images)
                .Where(p => p.productId.Equals(id))
                .AsNoTracking()
                .SingleAsync();

        }


        void PagingProducts (ref IEnumerable<Product> sourceProducts, int pageindex, int pagesize)
        {
            if (pageindex == 0)
            {
                return;
            }
            sourceProducts = sourceProducts.Skip((pageindex - 1) * pagesize).Take(pagesize);
        }

        void CategorizeProducts (ref IEnumerable<Product> sourceProducts, int cateId)
        {
            if (cateId != 0)
            {
                sourceProducts = allProduct.Where(x => x.categoryId == cateId);
                productLength = sourceProducts.Count();
            }
        }

        void FilterProducts (ref IEnumerable<Product> sourceProducts, double? min, double? max)
        {

            if (min != null && min > 0)
            {
                sourceProducts = sourceProducts.Where(p => p.productPrice >= min);
            }
            if (max != null && max > 0)
            {
                sourceProducts = sourceProducts.Where(p => p.productPrice <= max);
            }
            productLength = sourceProducts.Count();
        }

        void SortProducts (ref IEnumerable<Product> sourceProducts, string sortorder)
        {
            if (String.IsNullOrWhiteSpace(sortorder) || sortorder == "asc")
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


        public async Task<Product> PostProduct (ProductPostRequest product)
        {
            var productAdded = _mapper.Map<Product>(product);
            productAdded.createdDate = productAdded.updatedDate = DateTime.Now;

            if (product.ImageFiles != null)
            {
                foreach (IFormFile file in product.ImageFiles)
                {
                    productAdded.Images.Add(new Image { productId = productAdded.productId, imageUrl = await _filesService.SaveFilePath(file) });
                }

            }
            try
            {
                _context.Add(productAdded);
                await _context.SaveChangesAsync();
                return productAdded;
            }
            catch (System.Exception)
            {
                return null;
            }

        }

        public async Task<Product> PutProduct (int id, ProductPostRequest product)
        {
            var productToBeUpdated = await _context.Products.FindAsync(id);

            if (productToBeUpdated is null)
            {
                return null;
            }

            productToBeUpdated.updatedDate = DateTime.Now;
            if (product.ImageFiles != null)
            {
                productToBeUpdated.Images = new List<Image>(); //reset to zero image
                foreach (IFormFile file in product.ImageFiles)
                {
                    productToBeUpdated.Images.Add(new Image { productId = productToBeUpdated.productId, imageUrl = await _filesService.SaveFilePath(file) });
                }

            }
            try
            {
                _context.Entry(productToBeUpdated).CurrentValues.SetValues(product);
                await _context.SaveChangesAsync();
                return productToBeUpdated;
            }
            catch (System.Exception e)
            {
                return null;
            }
        }

        public Task<int> DeleteProduct (int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
