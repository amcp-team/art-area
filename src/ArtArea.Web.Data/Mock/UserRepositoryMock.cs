using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;

namespace ArtArea.Web.Data.Mock
{
    // TODO [Andrey] implement all the methods via list
    public class UserRepositoryMock : IUserRepository
    {
        public async Task CreateUser(User user)
        {
            await Task.Run(() => ApplicationDbMock.Users.Add(user));
        }

        public async Task DeleteUser(string username)
        {
            await Task.Run(() => 
            {
                var user = ApplicationDbMock.Users
                    .SingleOrDefault(u => u.Username == username);

                if(user != null)
                    ApplicationDbMock.Users.Remove(user);
            });
        }

        public async Task<User> ReadUser(string username)
        {
            return await Task.Run(() => ApplicationDbMock.Users.SingleOrDefault(u => u.Username == username));
        }

        public async Task<IEnumerable<User>> ReadUsers()
        {
            return await Task.Run(() => ApplicationDbMock.Users);
        }

        public async Task UpdateUser(User user)
        {
            await Task.Run(() => 
            {
                var _user = ApplicationDbMock.Users
                    .SingleOrDefault(u => u.Username == user.Username);

                if(_user != null)
                    _user = user;
            });
        }
    }
}