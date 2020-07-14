using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Parsers;
using Dto;
using MongoDB.Bson.IO;
using Newtonsoft.Json.Linq;

namespace UnitTestProject.Parsers
{
    [TestClass]
    public class CocaColaParserUnitTest
    {
        [TestMethod]
        public void ConvertUserTest()
        {
            var user = new CocaColaUserDto
            {
                Id = "5f06df76a9bca433b45acb95",
                Email = "employee@cocacola.com",
                Fullname = "John Smith",
                Age = 30
            };

            var userJsonObject = JObject.Parse( Newtonsoft.Json.JsonConvert.SerializeObject(user) );

            var clientparser = new CocaColaParser();
            var userDb = ((IParser)clientparser).ConvertToStandardizedUserDto(userJsonObject);

            Assert.AreEqual(user.Id, userDb.Id);
            Assert.AreEqual(user.Email, userDb.Email);
            Assert.AreEqual(user.Fullname, $"{userDb.FirstName} {userDb.LastName}");
            Assert.AreEqual(user.Age, userDb.Age);
        }
    }
}
