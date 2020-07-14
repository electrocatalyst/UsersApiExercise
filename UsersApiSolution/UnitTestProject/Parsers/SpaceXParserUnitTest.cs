using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Parsers;
using Dto;
using Newtonsoft.Json.Linq;

namespace UnitTestProject.Parsers
{
    [TestClass]
    public class SpaceXParserUnitTest
    {
        [TestMethod]
        public void ConvertUserTest()
        {
            var user = new SpaceXUserDto();
            user.Id = "5f06df76a9bca433b45acb95";
            user.Email = "employee@cocacola.com";
            user.Fullname = "John Smith";

            JObject userJsonObject = JObject.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(user));

            var clientparser = new SpaceXParser();
            var userDb = ((IParser)clientparser).ConvertToStandardizedUserDto(userJsonObject);

            Assert.AreEqual(user.Id, userDb.Id);
            Assert.AreEqual(user.Email, userDb.Email);
            Assert.AreEqual(user.Fullname, userDb.FirstName + " " + userDb.LastName);
        }
    }
}
