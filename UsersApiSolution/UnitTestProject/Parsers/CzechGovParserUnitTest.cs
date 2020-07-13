using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Parsers;
using DbComm.Models;
using MongoDB.Bson;

namespace UnitTestProject.Parsers
{
    [TestClass]
    public class CzechGovParserUnitTest
    {
        [TestMethod]
        public void ConvertUserTest()
        {
            CzechGovUserDto user = new CzechGovUserDto();
            user.Id = new ObjectId("5f06df76a9bca433b45acb95");
            user.Email = "employee@cocacola.com";
            user.FirstName = "John";
            user.LastName = "Smith";
            user.Age = 30;

            CzechGovParser ccparser = new CzechGovParser();
            var userDb = ((IParser)ccparser).ConvertToStandardizedUserDto(user);

            Assert.AreEqual(user.Id, userDb.Id);
            Assert.AreEqual(user.Email, userDb.Email);
            Assert.AreEqual(user.FirstName, userDb.FirstName);
            Assert.AreEqual(user.LastName, userDb.LastName);
            Assert.AreEqual(user.Age, userDb.Age);
        }
    }
}
