using BusinessLogic.Parsers;
using Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace UnitTestProject.Parsers
{
    [TestClass]
    public class CzechGovParserUnitTest
    {
        [TestMethod]
        public void ConvertUserTest()
        {
            CzechGovUserDto user = new CzechGovUserDto();
            user.Id = "5f06df76a9bca433b45acb95";
            user.Email = "employee@cocacola.com";
            user.FirstName = "John";
            user.LastName = "Smith";
            user.Age = 30;

            JObject userJsonObject = JObject.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(user));

            CzechGovParser clientparser = new CzechGovParser();
            var userDb = ((IParser)clientparser).ConvertToStandardizedUserDto(userJsonObject);

            Assert.AreEqual(user.Id, userDb.Id);
            Assert.AreEqual(user.Email, userDb.Email);
            Assert.AreEqual(user.FirstName, userDb.FirstName);
            Assert.AreEqual(user.LastName, userDb.LastName);
            Assert.AreEqual(user.Age, userDb.Age);
        }
    }
}
