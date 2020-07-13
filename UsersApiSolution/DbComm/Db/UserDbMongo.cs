using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using DbComm.Models;

namespace DbComm.Db
{

    public class UserDbMongo : IUserDbAccessLayer
    {
        public UserDbMongo()
        {
            var connectionString = "mongodb://localhost:27017";
            var dbclient = new MongoClient(connectionString);
            _usersdb = dbclient.GetDatabase("usersapidb");
        }

        private IMongoDatabase _usersdb;

        public async Task<ObjectId> InsertUserAsync(UserDb userdb)
        {
            var collection = _usersdb.GetCollection<UserDb>("Users");
            await collection.InsertOneAsync(userdb);
            return userdb.Id;
        }

        public async Task UpdateUserAsync(string id, UserDb userdb)
        {
            if(userdb != null && userdb.Id == ObjectId.Empty)
                userdb.Id = ObjectId.Parse(id);

            

            var collection = _usersdb.GetCollection<UserDb>("Users");
            await collection.ReplaceOneAsync(u => u.Id == ObjectId.Parse(id), userdb, new ReplaceOptions { IsUpsert = true });
        }

        public async Task<UserDb> GetUserAsync(string id)
        {
            var collection = _usersdb.GetCollection<UserDb>("Users");
            var userdb = await collection.Find(u => u.Id == ObjectId.Parse(id)).FirstOrDefaultAsync();
            
            return userdb;
        }

        public async Task<List<UserDb>> GetUsersAsync()
        {
            // FIXME: the returned collection should contain Dto objects
            var collection = await _usersdb.GetCollection<UserDb>("Users").Find(_ => true).ToListAsync();
            return collection;
        }

        public async Task DeleteUserAsync(string id)
        {
            IMongoCollection<UserDb> collection = _usersdb.GetCollection<UserDb>("Users");
            await collection.DeleteOneAsync(u => u.Id == ObjectId.Parse(id));
        }
    }
}
