using System.Threading.Tasks;
using BusinessLogic.Core;
using BusinessLogic.Logging;
using DbComm.Db;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject.Db
{
    [TestClass]
    public class CrudTest
    {
        // TODO: create tests for CRUD

        // TODO: use logger

        [TestMethod]
        public async Task CreateTest()
        {
            // Create the mock
            var mock = new Mock<ILogger>();

            // Configure the mock to do something
            mock.Setup(x => x.LogMessage("test")).Returns(true);
            
            // Demonstrate that the configuration works
            Assert.AreEqual(true, mock.Object.LogMessage("test"));


            // perform the db saving here
            var dataproc = new DataProcessor(mock.Object, new UserDbMongo(), new ParsingManager());
            await dataproc.SaveNewPersonAsync(GenerateJsonData("CocaColaParser"));
            

            // Verify that the mock was invoked (the method LogMessage was called when performing DataProcessing work)
            mock.Verify(x => x.LogMessage("test"));
            // verify() passes even if I don't call the SaveNewPersonAsync() method


        }




        

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

        private string _email = "coke@cocacola.com";
        private string _firstname = "John";
        private string _lastname = "Wick";
        private int _age = 30;
    }
}
