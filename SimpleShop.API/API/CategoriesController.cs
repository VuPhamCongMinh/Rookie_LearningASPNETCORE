using Microsoft.AspNetCore.Mvc;
using SimpleShop.API.Services;
using SimpleShop.Shared.Interfaces;
using SimpleShop.Shared.Models;
using SimpleShop.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleShop.API.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategorySevice _categoryService;

        public CategoriesController (ICategorySevice categoryService)
        {
            _categoryService = categoryService;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryResponse>>> GetCategories ()
        {
            return Ok(new CategoryResponse { Categories = await _categoryService.GetCategories() });
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory (int id)
        {
            return Ok(await _categoryService.GetCategoryById(id));
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult<Category>> Post ([FromForm] Category category)
        {
            var returnCate = await _categoryService.PostCategory(category);
            if (returnCate is null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetCategory), new { id = returnCate.categoryId });
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> Put (int id, [FromForm] Category category)
        {
            var returnCate = await _categoryService.PutCategory(id,category);
            if (returnCate is null)
            {
                return BadRequest();
            }
            return Ok(returnCate);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete (int id)
        {
        }
    }
}
