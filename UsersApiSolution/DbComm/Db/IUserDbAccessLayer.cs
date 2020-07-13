using System.Collections.Generic;
using System.Threading.Tasks;
using DbComm.Models;
using MongoDB.Bson;

namespace DbComm.Db
{
    public interface IUserDbAccessLayer
    {
        Task<ObjectId> InsertUserAsync(UserDb userdto);

        Task UpdateUserAsync(string id, UserDb userdto);

        Task<UserDb> GetUserAsync(string id);

        Task<List<UserDb>> GetUsersAsync();

        Task DeleteUserAsync(string id);
    }
}
