using System.Collections.Generic;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data;
using ArtArea.Web.Data.Interface;
using MongoDB.Bson;
using MongoDB.Driver;

public class UserRepository : IUserRepository
{
    public ApplicationDb db;
    public UserRepository(ApplicationDb database) => db = database;
    public async Task CreateUser(User user)
        => await db.Users.InsertOneAsync(user);

    public async Task DeleteUser(string name)
        => await db.Users.DeleteOneAsync(x => x.Name == name);

    public async Task<User> ReadUser(string name)
        => await db.Users.Find(x => x.Name == name).FirstOrDefaultAsync();

    public async Task<IEnumerable<User>> ReadUsers()
        => await db.Users.Find(x => true).ToListAsync();

    public async Task UpdateUser(User user)
        => await db.Users.ReplaceOneAsync(new BsonDocument("id", user.Id), user);
}