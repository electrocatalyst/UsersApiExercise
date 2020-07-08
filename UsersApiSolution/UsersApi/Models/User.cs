using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UsersApi.Models
{
    public class User
    {
        public string Nickname { get; set; }
        public string RealName { get; set; }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
    }
}
