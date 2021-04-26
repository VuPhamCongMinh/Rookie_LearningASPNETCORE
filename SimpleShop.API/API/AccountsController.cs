using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Shared.EF;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleShop.API.API
{
    [Route("api/[controller]")]
    [Authorize("Admin")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly MyDBContext context;

        public AccountsController (MyDBContext context)
        {
            this.context = context;
        }
        // GET: api/<AccountsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentityUser>>> GetUsers ()
        {
            var users = await context.Users.ToListAsync();
            return Ok(users);
        }

        // GET api/<AccountsController>/5
        [HttpGet("{id}")]
        public string Get (int id)
        {
            return "value";
        }

        // POST api/<AccountsController>
        [HttpPost]
        public void Post ([FromBody] string value)
        {
        }

        // PUT api/<AccountsController>/5
        [HttpPut("{id}")]
        public void Put (int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountsController>/5
        [HttpDelete("{id}")]
        public void Delete (int id)
        {
        }
    }
}
