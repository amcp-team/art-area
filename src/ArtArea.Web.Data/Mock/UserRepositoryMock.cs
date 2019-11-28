using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;

namespace ArtArea.Web.Data.Mock
{
    public class UserRepositoryMock : IUserRepository
    {
        private IProjectRepository _projectRepository = new ProjectRepositoryMock();
        public async Task CreateUser(User user)
        {
            await Task.Run(() =>
            {
                var existingUser = ApplicationDbMock.Users
                    .SingleOrDefault(u => u.Username == user.Username);

                if(existingUser == null)
                    ApplicationDbMock.Users.Add(user);
                else throw new Exception("User already exists");
            });
        }
        public async Task DeleteUser(string username)
        {
            await Task.Run(() => 
            {
                var user = ApplicationDbMock.Users
                    .SingleOrDefault(u => u.Username == username);

                if(user != null)
                {
                    var projectsToDelete = ApplicationDbMock.Projects
                        .Where(project => project.HostUsername == username);

                    foreach(var project in projectsToDelete)
                        _projectRepository.DeleteProject(project.Id);

                    ApplicationDbMock.Users.Remove(user);
                }
                else throw new Exception("Can't delete user - one doesn't exist");
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
                else throw new Exception("No such user"); 
            });
        }
    }
}