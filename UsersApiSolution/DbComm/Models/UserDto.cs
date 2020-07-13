using MongoDB.Bson;

namespace DbComm.Models
{
    public class UserDto : IPersonDto
    {
        public ObjectId Id { get; set; }
        public string Email { get; set; }
        
        public string Nickname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
