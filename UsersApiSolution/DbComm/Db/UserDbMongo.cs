using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using DbComm.Mappers;
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

        public async Task<ObjectId> InsertUserAsync(UserDto userdto)
        {
            UserDb user = UserModelMapper.UserDtoToDbModel(userdto);

            var collection = _usersdb.GetCollection<UserDb>("Users");
            await collection.InsertOneAsync(user);
            return user.Id;
        }

        public async Task UpdateUserAsync(string id, UserDto userdto)
        {
            if(userdto != null && userdto.Id == ObjectId.Empty)
                userdto.Id = ObjectId.Parse(id);

            UserDb user = UserModelMapper.UserDtoToDbModel(userdto);

            var collection = _usersdb.GetCollection<UserDb>("Users");
            await collection.ReplaceOneAsync(u => u.Id == ObjectId.Parse(id), user, new ReplaceOptions { IsUpsert = true });
        }

        public async Task<UserDto> GetUserAsync(string id)
        {
            var collection = _usersdb.GetCollection<UserDb>("Users");
            var userdb = await collection.Find(u => u.Id == ObjectId.Parse(id)).FirstOrDefaultAsync();

            UserDto result = UserModelMapper.UserDbToDtoModel(userdb);

            return result;
        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
            // FIXME: the returned collection should contain Dto objects
            var collection = await _usersdb.GetCollection<UserDto>("Users").Find(_ => true).ToListAsync();
            return collection;
        }

        public async Task DeleteUserAsync(string id)
        {
            IMongoCollection<UserDb> collection = _usersdb.GetCollection<UserDb>("Users");
            await collection.DeleteOneAsync(u => u.Id == ObjectId.Parse(id));
        }
    }
}
