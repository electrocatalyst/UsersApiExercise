using Dto;
using Newtonsoft.Json.Linq;

namespace BusinessLogic.Parsers
{
    public class CocaColaParser : IParser
    {
        UserDto IParser.ConvertToStandardizedUserDto(JObject person)
        {
            var ccperson = Newtonsoft.Json.JsonConvert.DeserializeObject<CocaColaUserDto>(person.ToString());

            UserDto user = new UserDto();
            user.Id = ccperson.Id;
            user.Email = ccperson.Email;

            user.Nickname = ccperson.Email;
            user.FirstName = ccperson.Fullname.Split(' ')[0];
            user.LastName = ccperson.Fullname.Split(' ')[1];
            user.Age = ccperson.Age;

            return user;
        }
    }
}
