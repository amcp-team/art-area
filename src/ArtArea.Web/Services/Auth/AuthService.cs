using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtArea.Web.Controllers;
using ArtArea.Web.Data.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ArtArea.Web.Services.Auth
{
    public class AuthService
    {
        private IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<bool> CheckUserLogin(string login, string password)
        {
            return Task.Run(() =>
            {
                if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password)) return false;
                
                var user = _userRepository.ReadUser(login);

                return user != null && user.Result.Password == password;
            });
        }




    }
}
