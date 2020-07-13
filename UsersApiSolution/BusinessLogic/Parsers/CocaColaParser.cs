using DbComm.Models;

namespace BusinessLogic.Parsers
{
    public class CocaColaParser : IParser
    {
        UserDto IParser.ConvertToStandardizedUserDto(IPersonDto person)
        {
            CocaColaUserDto ccperson = (CocaColaUserDto) person;

            UserDto user = new UserDto();
            user.Id = ccperson.Id;
            user.Email = ccperson.Email;

            user.Nickname = ccperson.Email;
            user.FirstName = ccperson.Fullname.Split(' ')[0]; // FIXME: validate
            user.LastName = ccperson.Fullname.Split(' ')[1];
            user.Age = ccperson.Age;

            return user;
        }
    }
}
