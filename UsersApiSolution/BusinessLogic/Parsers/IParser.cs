using Dto;
using Newtonsoft.Json.Linq;

namespace BusinessLogic.Parsers
{
    public interface IParser
    {
        UserDto ConvertToStandardizedUserDto(JObject person);
    }
}
