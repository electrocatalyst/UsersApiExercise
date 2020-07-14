using BusinessLogic.Core;
using BusinessLogic.Parsers;
using Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject.Parsers
{
    [TestClass]
    public class ParserSelectionUnitTest
    {
        [TestMethod]
        public void JsonParserSelectionUnitTest()
        {
            var incomingJson = GenerateJsonData(parserName: typeof(CocaColaParser).ToString());

            var parsingManager = new ParsingManager();
            var userdto = parsingManager.ParseData(incomingJson);
            
            Assert.AreEqual(userdto.Email, _email);
            Assert.AreEqual(userdto.FirstName, _firstname);
            Assert.AreEqual(userdto.LastName, _lastname);
            Assert.AreEqual(userdto.Age, _age);
        }

        private string _email = "coke@cocacola.com";
        private string _firstname = "John";
        private string _lastname = "Wick";
        private int _age = 30;

        private string GenerateJsonData(string parserName)
        {
            string incomingJson = $"{{" +
                                  $"parser: \"{parserName}\", " +
                                  $"person: {{" +
                                  $"    Id: \"\"," +
                                  $"    Email: \"{_email}\"," +
                                  $"    Fullname: \"{_firstname} {_lastname}\"," +
                                  $"    Age: \"{_age}\"," +
                                  $"    }}" +
                                  $"}}";

            return incomingJson;
        }
    }
}
