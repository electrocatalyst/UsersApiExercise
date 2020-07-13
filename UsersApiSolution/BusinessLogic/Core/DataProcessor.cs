using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Logging;
using BusinessLogic.Parsers;
using DbComm.Db;
using DbComm.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BusinessLogic.Core
{
    public class DataProcessor : IDataProcessor
    {
        private readonly ILogger _logger;
        private readonly IUserDbAccessLayer _dbmanager;


        public DataProcessor(ILogger logger, IUserDbAccessLayer dbmanager)
        {
            _logger = logger;
            _dbmanager = dbmanager;
        }


        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            _logger.LogMessage("Retrieved users from db.");
            return await _dbmanager.GetUsersAsync();
        }

        public async Task<UserDto> GetOneUserAsync(string id)
        {
            _logger.LogMessage("Retrieved a user from db.");
            return await _dbmanager.GetUserAsync(id);
        }

        public async Task SaveNewPersonAsync(string person)
        {
            var userDto = this.ParseData(person);
            
            await _dbmanager.InsertUserAsync(userDto);
            _logger.LogMessage("Saved a user to db.");
        }

        public async Task UpdateExistingUserAsync(string id, string person)
        {
            var userDto = this.ParseData(person);

            await _dbmanager.UpdateUserAsync(id, userDto);
            _logger.LogMessage("Updated a user in db.");
        }

        public async Task DeleteUserAsync(string id)
        {
            await _dbmanager.DeleteUserAsync(id);
            _logger.LogMessage("Deleted a user from db.");
        }


        private UserDto ParseData(string person)
        {
            // Check parser and convert data to one of the user objects
            JObject requestBody = JObject.Parse(person);

            Type type = Type.GetType(typeName: requestBody["parser"]?.ToString() ?? string.Empty);
            IParser parser = (IParser)Activator.CreateInstance(type ?? typeof(UserParser));

            // Get JSON object from the request body
            var userData = (JObject)requestBody["person"];

            // Deserialize JSON into a C# object
            if (userData != null)
            {
                IPersonDto nonStandardizedPerson = JsonConvert.DeserializeObject<CocaColaUserDto>(userData.ToString());

                UserDto userDto = parser.ConvertToStandardizedUserDto(nonStandardizedPerson);

                return userDto;
            }
            else return null;
        }
    }
}
