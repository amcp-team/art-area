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


        public Task<bool> UserExist(string username)
        {
            var user = _userRepository.ReadUser(username).Result;
            return Task.Run(() =>
            {
                return (user == null) ;
               
            });
        }

        public Task<User> GetUser(string username)
        {
            return Task.Run(() =>
            {
                if (UserExist(username).Result)
                    return _userRepository.ReadUser(username).Result;
                else throw new Exception("No user in DB");

            });
           
        }
    }
}
