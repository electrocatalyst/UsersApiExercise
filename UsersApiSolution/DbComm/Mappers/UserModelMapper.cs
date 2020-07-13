using DbComm.Models;

namespace DbComm.Mappers
{
    internal class UserModelMapper
    {
        public static UserDb UserDtoToDbModel(UserDto user) =>
            new UserDb()
            {
                Id = user.Id,
                Email = user.Email,

                Nickname = user.Nickname,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
            };

        public static UserDto UserDbToDtoModel(UserDb user) =>
            new UserDto()
            {
                Id = user.Id,
                Email = user.Email,

                Nickname = user.Nickname,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
            };
    }
}
