using Dto;
using Newtonsoft.Json.Linq;

namespace BusinessLogic.Parsers
{
    public class SpaceXParser : IParser
    {
        UserDto IParser.ConvertToStandardizedUserDto(JObject person)
        {
            SpaceXUserDto ccperson = Newtonsoft.Json.JsonConvert.DeserializeObject<SpaceXUserDto>(person.ToString());

            UserDto user = new UserDto();
            user.Id = ccperson.Id;
            user.Email = ccperson.Email;

            user.Nickname = ccperson.Email;
            user.FirstName = ccperson.Fullname.Split(' ')[0]; // FIXME: validate
            user.LastName = ccperson.Fullname.Split(' ')[1];
            user.Age = 0;
            
            return user;
        }
    }
}
