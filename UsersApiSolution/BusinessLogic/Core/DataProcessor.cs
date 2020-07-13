using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Logging;
using BusinessLogic.Mappers;
using DbComm.Db;
using DbComm.Models;
using Dto;

namespace BusinessLogic.Core
{
    public class DataProcessor : IDataProcessor
    {
        private readonly ILogger _logger;
        private readonly IUserDbAccessLayer _dbmanager;
        private readonly IParsingManager _parsingManager;


        public DataProcessor(ILogger logger, IUserDbAccessLayer dbmanager, IParsingManager parsingManager)
        {
            _logger = logger;
            _dbmanager = dbmanager;
            _parsingManager = parsingManager;
        }


        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            _logger.LogMessage("Retrieved users from db.");
            List<UserDb> dbCollection = await _dbmanager.GetUsersAsync();
            List<UserDto> dtoCollection = dbCollection.ConvertAll(UserModelMapper.UserDbToDtoModel);

            return dtoCollection;
        }

        public async Task<UserDto> GetOneUserAsync(string id)
        {
            _logger.LogMessage("Retrieved a user from db.");
            UserDb userdb = await _dbmanager.GetUserAsync(id);
            UserDto userdto = UserModelMapper.UserDbToDtoModel(userdb);

            return userdto;
        }

        public async Task SaveNewPersonAsync(string person)
        {
            var userDto = _parsingManager.ParseData(person: person);

            UserDb userdb = UserModelMapper.UserDtoToDbModel(userDto);

            await _dbmanager.InsertUserAsync(userdb);
            _logger.LogMessage("Saved a user to db.");
        }

        public async Task UpdateExistingUserAsync(string id, string person)
        {
            var userDto = _parsingManager.ParseData(person);

            UserDb userdb = UserModelMapper.UserDtoToDbModel(userDto);

            await _dbmanager.UpdateUserAsync(id, userdb);
            _logger.LogMessage("Updated a user in db.");
        }

        public async Task DeleteUserAsync(string id)
        {
            await _dbmanager.DeleteUserAsync(id);
            _logger.LogMessage("Deleted a user from db.");
        }
    }
}
