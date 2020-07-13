using System;
using System.Reflection;
using BusinessLogic.Parsers;
using Dto;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BusinessLogic.Core
{
    public class ParsingManager : IParsingManager
    {
        public UserDto ParseData(string person)
        {
            UserDto ret = null;
            // Check parser and convert data to one of the user objects
            var requestBody = JObject.Parse(person);

            var type = Type.GetType(typeName: requestBody["parser"]?.ToString() ?? string.Empty);
            var parser = (IParser)Activator.CreateInstance(type ?? typeof(UserParser));

            // Get JSON object from the request body
            var userData = (JObject)requestBody["person"];

            // Deserialize JSON into a C# object
            if (userData != null)
            {
                var settings = new JsonSerializerSettings();
                settings.SerializationBinder.BindToType(Assembly.GetExecutingAssembly().ToString(), parser.GetType().ToString());
                IPersonDto nonStandardizedPerson = (IPersonDto)JsonConvert.DeserializeObject(userData.ToString(), settings);

                var userDto = parser.ConvertToStandardizedUserDto(nonStandardizedPerson);

                ret = userDto;
            }

            return ret;
        }
    }
}
