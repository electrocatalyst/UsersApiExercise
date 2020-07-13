using MongoDB.Bson;

namespace DbComm.Models
{
    public interface IPersonDto
    {
        ObjectId Id { get; set; }

        string Email { get; set; }
    }
}
