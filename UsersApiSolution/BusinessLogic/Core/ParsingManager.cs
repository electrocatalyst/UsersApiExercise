using System;
using BusinessLogic.Parsers;
using Dto;
using Newtonsoft.Json.Linq;

namespace BusinessLogic.Core
{
    public class ParsingManager : IParsingManager
    {
        public UserDto ParseData(string incomingData)
        {
            UserDto ret = null;
            // Convert to JObject for now, to get the parser name easily
            var requestBody = JObject.Parse(incomingData);

            // Instantiate the parser
            var type = Type.GetType(typeName: requestBody["parser"]?.ToString() ?? string.Empty);
            var parser = (IParser)Activator.CreateInstance(type ?? typeof(UserParser));

            // Get JSON object from the request body
            var userData = (JObject)requestBody["person"];

            // Deserialize JSON into a C# object
            if (userData != null)
            {
                var userDto = parser.ConvertToStandardizedUserDto(userData);
                ret = userDto;
            }

            return ret;
        }
    }
}
