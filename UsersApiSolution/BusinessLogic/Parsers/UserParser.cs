using Dto;
using Newtonsoft.Json.Linq;

namespace BusinessLogic.Parsers
{
    public class UserParser : IParser
    {
        UserDto IParser.ConvertToStandardizedUserDto(JObject person)
        {
            UserDto ccperson = Newtonsoft.Json.JsonConvert.DeserializeObject<UserDto>(person.ToString());

            UserDto user = new UserDto();
            user.Id = ccperson.Id;
            user.Email = ccperson.Email;

            user.Nickname = ccperson.Email;
            user.FirstName = ccperson.Email;
            user.LastName = ccperson.Email;
            user.Age = 0;

            return user;
        }
    }
}
