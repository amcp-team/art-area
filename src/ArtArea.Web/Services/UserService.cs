using System.Net;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtArea.Web.Services
{
    public class UserService
    {
        private IUserRepository _userRepository;
        private IProjectRepository _projectRepository;
        public UserService(
            IUserRepository userRepository,
            IProjectRepository projectRepository)
        {
            _userRepository = userRepository;
            _projectRepository = projectRepository;
        }

        public bool UserExist(string username)
            => _userRepository.ReadUser(username) != null;

        public Task<User> GetUserAsync(string username)
        {
            if (UserExist(username))
                return _userRepository.ReadUserAsync(username);
            else
                throw new Exception("No user in DB");
        }

        public User GetUser(string username)
        {
            if (UserExist(username))
                return _userRepository.ReadUser(username);
            else
                throw new Exception("No user in DB");
        }

        public Task<IEnumerable<Project>> GetUserProjects(string username, string loggedInUsername = null)
        {
            if (!UserExist(username))
                throw new Exception("No user in DB");

            return Task.Run(async () =>
            {
                var projects = await _projectRepository.ReadProjectsAsync();

                return projects
                    .Where(x => x.Collaborators.Any(y =>
                        y.Username == username && y.Username == (loggedInUsername ?? y.Username) ||
                        y.Username == username && !x.IsPrivate))
                    .AsEnumerable();
            });
        }
    }
}
