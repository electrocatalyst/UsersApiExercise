using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Core;
using BusinessLogic.Logging;
using Microsoft.AspNetCore.Mvc;
using Dto;


namespace UsersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
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
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<UserDto> Get(string id)
        {
            _logger.LogMessage("Controller GET for one user called.");
            return await _dataProcessor.GetOneUserAsync(id);
        }

        // POST: api/User
        [HttpPost]
        public async Task Post([FromBody] string value)
        {
            _logger.LogMessage("Controller POST called.");
            await _dataProcessor.SaveNewPersonAsync(value);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody] string value)
        {
            _logger.LogMessage("Controller PUT called.");
            await _dataProcessor.UpdateExistingUserAsync(id, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            _logger.LogMessage("Controller DELETE called.");
            await _dataProcessor.DeleteUserAsync(id);
        }
    }
}
