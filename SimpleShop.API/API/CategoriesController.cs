using Microsoft.AspNetCore.Mvc;
using SimpleShop.Shared.Services;
using SimpleShop.Shared.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SimpleShop.API.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoriesController (CategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public ActionResult<IEnumerable<CategoryResponse>> GetCategories ()
        {
            return Ok(new CategoryResponse { Categories = _categoryService.GetCategories() });
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public string Get (int id)
        {
            return "value";
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public void Post ([FromBody] string value)
        {
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put (int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete (int id)
        {
        }
    }
}
