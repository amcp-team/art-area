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
        private List<User> users;

        public async Task CreateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteUserById(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteUserByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetUserById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetUserByName(string Name)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateUserById(string id, User user)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateUserByName(string name, User user)
        {
            throw new System.NotImplementedException();
        }
    }
}