using Dto;
using Newtonsoft.Json.Linq;

namespace BusinessLogic.Parsers
{
    public class CzechGovParser : IParser
    {
        UserDto IParser.ConvertToStandardizedUserDto(JObject person)
        {
            CzechGovUserDto ccperson = Newtonsoft.Json.JsonConvert.DeserializeObject<CzechGovUserDto>(person.ToString());

            UserDto user = new UserDto();
            user.Id = ccperson.Id;
            user.Email = ccperson.Email;

            user.Nickname = ccperson.Email;
            user.FirstName = ccperson.FirstName;
            user.LastName = ccperson.LastName;
            user.Age = ccperson.Age;

            return user;
        }
    }
}
