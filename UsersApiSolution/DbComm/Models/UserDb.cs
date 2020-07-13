using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DbComm.Models
{
    internal class UserDb
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string Email { get; set; }

        public string Nickname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
