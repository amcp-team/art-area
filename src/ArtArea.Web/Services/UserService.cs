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
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
    }
}
