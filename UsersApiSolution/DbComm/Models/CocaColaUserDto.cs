using MongoDB.Bson;

namespace DbComm.Models
{
    public class CocaColaUserDto : IPersonDto
    {
        public ObjectId Id { get; set; }
        public string Email { get; set; }

        public string Fullname { get; set; }
        public int Age { get; set; }
    }
}
