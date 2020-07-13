using Dto;

namespace BusinessLogic.Parsers
{
    public interface IParser
    {
        UserDto ConvertToStandardizedUserDto(IPersonDto person);
    }
}
