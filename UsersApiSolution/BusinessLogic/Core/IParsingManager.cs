using Dto;

namespace BusinessLogic.Core
{
    public interface IParsingManager
    {
        UserDto ParseData(string person);
    }
}
