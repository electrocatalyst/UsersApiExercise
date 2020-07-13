using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Parsers;
using DbComm.Models;
using MongoDB.Bson;

namespace UnitTestProject.Parsers
{
    [TestClass]
    public class SpaceXParserUnitTest
    {
        [TestMethod]
        public void ConvertUserTest()
        {
            SpaceXUserDto user = new SpaceXUserDto();
            user.Id = new ObjectId("5f06df76a9bca433b45acb95");
            user.Email = "employee@cocacola.com";
            user.Fullname = "John Smith";

            SpaceXParser ccparser = new SpaceXParser();
            var userDb = ((IParser)ccparser).ConvertToStandardizedUserDto(user);

            Assert.AreEqual(user.Id, userDb.Id);
            Assert.AreEqual(user.Email, userDb.Email);
            Assert.AreEqual(user.Fullname, userDb.FirstName + " " + userDb.LastName);
        }
    }
}
