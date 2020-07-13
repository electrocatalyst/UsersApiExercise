using System.Collections.Generic;
using System.Threading.Tasks;
using DbComm.Models;

namespace BusinessLogic.Core
{
    public interface IDataProcessor
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();

        Task<UserDto> GetOneUserAsync(string id);

        Task SaveNewPersonAsync(string person);

        Task UpdateExistingUserAsync(string id, string person);

        Task DeleteUserAsync(string id);
    }
}
