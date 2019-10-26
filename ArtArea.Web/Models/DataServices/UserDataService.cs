using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.IO;
using MongoDB.Driver;

namespace ArtArea.Web.Models.DataServices
{
    public class UserDataService : IUserDataService
    {
        public ApplicationDb db;
        public UserDataService(ApplicationDb database) => db = database;
        public async Task AddUser(User user)
            => await db.Users.InsertOneAsync(user);

        public async Task DeleteUser(string id)
            => await db.Users.DeleteOneAsync(x => x.Id == id);

        public async Task<User> GetUser(string id)
            => await db.Users.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<User>> GetUsers() 
            => await db.Users.Find(x => true).ToListAsync();

        public async Task UpdateUser(User user)
            => await db.Users.ReplaceOneAsync(new BsonDocument("id", user.Id), user);
    }
}
