using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsersApi.Models;

namespace UsersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserDbAccessLayer UserDbAccess { get; } = new UserDbAccessLayer();

        // GET: api/User
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await UserDbAccess.GetUsersAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<User> Get(string id)
        {
            //return "value";
            return await UserDbAccess.GetUserAsync(id);
        }

        // POST: api/User
        [HttpPost]
        public async void Post([FromBody] User value)
        {
            if (UserDbAccess != null)
            {
                await UserDbAccess.InsertUserAsync(value);
            }
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] User value)
        {
            UserDbAccess.UpdateUserAsync(id, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            UserDbAccess.DeleteUserAsync(id);
        }
    }
}
