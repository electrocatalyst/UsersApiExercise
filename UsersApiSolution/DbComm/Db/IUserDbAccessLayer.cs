using System.Collections.Generic;
using System.Threading.Tasks;
using DbComm.Models;
using MongoDB.Bson;

namespace DbComm.Db
{
    public interface IUserDbAccessLayer
    {
        Task<ObjectId> InsertUserAsync(UserDto userdto);

        Task UpdateUserAsync(string id, UserDto userdto);

        Task<UserDto> GetUserAsync(string id);

        Task<List<UserDto>> GetUsersAsync();

        Task DeleteUserAsync(string id);
    }
}
