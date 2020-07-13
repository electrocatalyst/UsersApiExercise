using DbComm.Models;
using Dto;
using MongoDB.Bson;

namespace BusinessLogic.Mappers
{
    public class UserModelMapper
    {
        public static UserDb UserDtoToDbModel(UserDto user) =>
            new UserDb()
            {
                Id = ObjectId.Parse(user.Id),
                Email = user.Email,

                Nickname = user.Nickname,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
            };

        public static UserDto UserDbToDtoModel(UserDb user) =>
            new UserDto()
            {
                Id = user.Id.ToString(),
                Email = user.Email,

                Nickname = user.Nickname,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
            };
    }
}
