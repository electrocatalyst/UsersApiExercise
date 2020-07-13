using Dto;

namespace BusinessLogic.Parsers
{
    public class CzechGovParser : IParser
    {
        UserDto IParser.ConvertToStandardizedUserDto(IPersonDto person)
        {
            CzechGovUserDto ccperson = (CzechGovUserDto) person;

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
