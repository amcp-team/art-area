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

        public void CreateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public async Task CreateUserAsync(User user)
            => await _database.Users.InsertOneAsync(user);

        public void DeleteUser(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteUserAsync(string username)
            => await _database.Users.DeleteOneAsync(x => x.Username == username);

        public User ReadUser(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> ReadUserAsync(string username)
            => await _database.Users.Find(x => x.Username == username).FirstOrDefaultAsync();

        public IEnumerable<User> ReadUsers()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<User>> ReadUsersAsync()
            => await _database.Users.Find(x => true).ToListAsync();

        public void UpdateUser(User user)
        {
            throw new System.NotImplementedException();
        }


        // TODO check if mongo will store Username property which is marked
        // as BsonId as `username` or as '_id'
        public async Task UpdateUserAsync(User user)
            => await _database.Users.ReplaceOneAsync(new BsonDocument("_id", user.Username), user);
    }
}