using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;

namespace ArtArea.Web.Data.Mock
{
    // TODO [A] fix async/await declaration 
    //      rename asyncronous methods (thhat return task) with Async postfix
    //      create syncronous methods that correspond existsing async
    public class UserRepositoryMock : IUserRepository
    {
        private IProjectRepository _projectRepository = new ProjectRepositoryMock();

        public void CreateUser(User user)
        {
            var existingUser = ApplicationDbMock.Users
                .SingleOrDefault(x => x.Username == user.Username);
            if (existingUser == null)
                ApplicationDbMock.Users.Add(user);
            else throw new Exception("User already exists");

        }

        public async Task CreateUserAsync(User user)
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

        public void DeleteUser(string name)
        {
            var userToDelete = ApplicationDbMock.Users
                .SingleOrDefault(u => u.Username == name);
            if (userToDelete != null)
            {
                var projectToDelete = ApplicationDbMock.Projects
                    .Where(project => project.HostUsername == name);
                foreach (var project in projectToDelete)
                    _projectRepository.DeleteProject(project.Id);

                ApplicationDbMock.Users.Remove(userToDelete);
            }
            else throw new Exception("Can't delete user - one doesn't exist");
        }

        public async Task DeleteUserAsync(string username)
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
                        _projectRepository.DeleteProjectAsync(project.Id);

                    ApplicationDbMock.Users.Remove(user);
                }
                else throw new Exception("Can't delete user - one doesn't exist");
            });
        }

        public User ReadUser(string name)
        {
            return ApplicationDbMock.Users.SingleOrDefault(x => x.Username == name);
        }

        public async Task<User> ReadUserAsync(string username)
        {
            return await Task.Run(() => ApplicationDbMock.Users.SingleOrDefault(u => u.Username == username));
        }

        public IEnumerable<User> ReadUsers()
        {
            return ApplicationDbMock.Users;
        }

        public async Task<IEnumerable<User>> ReadUsersAsync()
        {
            return await Task.Run(() => ApplicationDbMock.Users);
        }

        public void UpdateUser(User user)
        {
            var userToUpdate = ApplicationDbMock.Users
                .SingleOrDefault(x => x.Username == user.Username);
            if (userToUpdate != null)
                userToUpdate = user;
            else throw new Exception("No such user");
        }

        public async Task UpdateUserAsync(User user)
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