using System.Collections.Generic;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ArtArea.Web.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDb _database;
        public UserRepository(ApplicationDb database) => _database = database;
        public async Task CreateUser(User user)
            => await _database.Users.InsertOneAsync(user);

        public async Task DeleteUser(string username)
            => await _database.Users.DeleteOneAsync(x => x.Username == username);

        public async Task<User> ReadUser(string username)
            => await _database.Users.Find(x => x.Username == username).FirstOrDefaultAsync();

        public async Task<IEnumerable<User>> ReadUsers()
            => await _database.Users.Find(x => true).ToListAsync();

        // TODO check if mongo will store Username property which is marked
        // as BsonId as `username` or as '_id'
        public async Task UpdateUser(User user)
            => await _database.Users.ReplaceOneAsync(new BsonDocument("_id", user.Username), user);
    }
}