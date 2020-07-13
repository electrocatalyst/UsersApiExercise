using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Parsers;
using Dto;

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

            var ccparser = new SpaceXParser();
            var userDb = ((IParser)ccparser).ConvertToStandardizedUserDto(user);

            Assert.AreEqual(user.Id, userDb.Id);
            Assert.AreEqual(user.Email, userDb.Email);
            Assert.AreEqual(user.Fullname, userDb.FirstName + " " + userDb.LastName);
        }
    }
}
