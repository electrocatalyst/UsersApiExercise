using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UsersApi.Models
{

    public class UserDbAccessLayer
    {
        public UserDbAccessLayer()
        {
            var connectionString = "mongodb://localhost:27017";
            var dbclient = new MongoClient(connectionString);
            _usersdb = dbclient.GetDatabase("usersapidb");
        }

        private IMongoDatabase _usersdb;

        public async Task<ObjectId> InsertUserAsync(User user)
        {
            var collection = _usersdb.GetCollection<User>("Users");
            await collection.InsertOneAsync(user);
            return user.Id;
        }

        public async void UpdateUserAsync(string id, User user)
        {
            if(user != null && user.Id == ObjectId.Empty)
                user.Id = ObjectId.Parse(id);
            
            var collection = _usersdb.GetCollection<User>("Users");
            await collection.ReplaceOneAsync(u => u.Id == ObjectId.Parse(id), user, new ReplaceOptions { IsUpsert = true });
        }

        public async Task<User> GetUserAsync(string id)
        {
            var collection = _usersdb.GetCollection<User>("Users");
            var result = await collection.Find(u => u.Id == ObjectId.Parse(id)).FirstOrDefaultAsync();
            
            return result;
        }

        public async void DeleteUserAsync(string id)
        {
            IMongoCollection<User> collection = _usersdb.GetCollection<User>("Users");
            await collection.DeleteOneAsync(u => u.Id == ObjectId.Parse(id));
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var collection = await _usersdb.GetCollection<User>("Users").Find(_ => true).ToListAsync();
            return collection;
        }
    }
}
