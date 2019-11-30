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

        #region Syncronous

        public void CreateUser(User user)
        {
            var existingUser = ApplicationDbMock.Users
                .SingleOrDefault(x => x.Username == user.Username);
            if (existingUser == null)
                ApplicationDbMock.Users.Add(user);
            else throw new Exception("User already exists");

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
        public User ReadUser(string name)
        {
            return ApplicationDbMock.Users.SingleOrDefault(x => x.Username == name);
        }
        public IEnumerable<User> ReadUsers()
        {
            return ApplicationDbMock.Users;
        }
        public void UpdateUser(User user)
        {
            var userToUpdate = ApplicationDbMock.Users
                .SingleOrDefault(x => x.Username == user.Username);
            if (userToUpdate != null)
                userToUpdate = user;
            else throw new Exception("No such user");
        }
        #endregion

        #region Asyncronous

        public Task CreateUserAsync(User user)
        {
            var existingUser = ApplicationDbMock.Users
                .SingleOrDefault(u => u.Username == user.Username);

            if (existingUser == null)
                return Task.Run(() => ApplicationDbMock.Users.Add(user));
            else throw new Exception("User already exists");
        }
        public Task DeleteUserAsync(string username)
        {
            var user = ApplicationDbMock.Users
                .SingleOrDefault(u => u.Username == username);
            if (user != null)
            {
                var projectsToDelete = ApplicationDbMock.Projects
                    .Where(project => project.HostUsername == username)
                    .ToList();

                foreach (var project in projectsToDelete)
                    _projectRepository.DeleteProject(project.Id);

                return Task.Run(() => ApplicationDbMock.Users.Remove(user));
            }
            else throw new Exception("Can't delete user - one doesn't exist");
        }
        public Task<User> ReadUserAsync(string username)
        {
            return Task.Run(() => ApplicationDbMock.Users.SingleOrDefault(u => u.Username == username));
        }
        public Task<IEnumerable<User>> ReadUsersAsync()
        {
            return Task.Run(() => ApplicationDbMock.Users.AsEnumerable());
        }
        public Task UpdateUserAsync(User user)
        {
            return Task.Run(() =>
            {
                var _user = ApplicationDbMock.Users
                    .SingleOrDefault(u => u.Username == user.Username);

                if (_user != null)
                    _user = user;
                else throw new Exception("No such user");
            });
        }

        #endregion
    }
}