using DbComm.Models;

namespace BusinessLogic.Parsers
{
    public interface IParser
    {
        UserDto ConvertToStandardizedUserDto(IPersonDto person);
    }
}
