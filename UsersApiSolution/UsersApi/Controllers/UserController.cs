using System.Collections.Generic;
using System.Threading.Tasks;
<<<<<<< HEAD
using BusinessLogic.Core;
using BusinessLogic.Logging;
using Microsoft.AspNetCore.Mvc;
using DbComm.Models;

=======
using Microsoft.AspNetCore.Mvc;
using UsersApi.Models;
>>>>>>> 4077e494a1c9985f068e6f701635159e7cfe96ff

namespace UsersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
<<<<<<< HEAD
        private readonly ILogger _logger;

        private readonly IDataProcessor _dataProcessor;
        

        public UserController(ILogger logger, IDataProcessor dataProcessor)
        {
            _logger = logger;
            _dataProcessor = dataProcessor;
        }

        // GET: api/User
        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get()
        {
            _logger.LogMessage("Controller GET called.");
            return await _dataProcessor.GetAllUsersAsync();
=======
        private UserDbAccessLayer UserDbAccess { get; } = new UserDbAccessLayer();

        // GET: api/User
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await UserDbAccess.GetUsersAsync();
>>>>>>> 4077e494a1c9985f068e6f701635159e7cfe96ff
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
<<<<<<< HEAD
        public async Task<UserDto> Get(string id)
        {
            _logger.LogMessage("Controller GET for one user called.");
            return await _dataProcessor.GetOneUserAsync(id);
=======
        public async Task<User> Get(string id)
        {
            //return "value";
            return await UserDbAccess.GetUserAsync(id);
>>>>>>> 4077e494a1c9985f068e6f701635159e7cfe96ff
        }

        // POST: api/User
        [HttpPost]
<<<<<<< HEAD
        public async Task Post([FromBody] string value)
        {
            _logger.LogMessage("Controller POST called.");
            await _dataProcessor.SaveNewPersonAsync(value);
=======
        public async void Post([FromBody] User value)
        {
            if (UserDbAccess != null)
            {
                await UserDbAccess.InsertUserAsync(value);
            }
>>>>>>> 4077e494a1c9985f068e6f701635159e7cfe96ff
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
<<<<<<< HEAD
        public async Task Put(string id, [FromBody] string value)
        {
            _logger.LogMessage("Controller PUT called.");
            await _dataProcessor.UpdateExistingUserAsync(id, value);
=======
        public void Put(string id, [FromBody] User value)
        {
            UserDbAccess.UpdateUserAsync(id, value);
>>>>>>> 4077e494a1c9985f068e6f701635159e7cfe96ff
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
<<<<<<< HEAD
        public async Task Delete(string id)
        {
            _logger.LogMessage("Controller DELETE called.");
            await _dataProcessor.DeleteUserAsync(id);
=======
        public void Delete(string id)
        {
            UserDbAccess.DeleteUserAsync(id);
>>>>>>> 4077e494a1c9985f068e6f701635159e7cfe96ff
        }
    }
}
