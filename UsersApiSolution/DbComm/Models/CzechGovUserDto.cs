using MongoDB.Bson;

namespace DbComm.Models
{
    public class CzechGovUserDto : IPersonDto
    {
        public ObjectId Id { get; set; }
        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
