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
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories ()
        {
            return Ok(await _categoryService.GetCategories());
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory (int id)
        {
            var returnCate = await _categoryService.GetCategoryById(id);
            if (returnCate is null)
            {
                return BadRequest();
            }

            return Ok(returnCate);
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
            return CreatedAtAction(nameof(GetCategory), new { id = returnCate.categoryId }, returnCate);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> Put (int id, [FromForm] Category category)
        {
            var returnCate = await _categoryService.PutCategory(id, category);
            if (returnCate is null)
            {
                return BadRequest();
            }
            return Ok(returnCate);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete (int id)
        {
            var isDeleteSuccessful = await _categoryService.DeleteCategory(id);
            if (isDeleteSuccessful)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
