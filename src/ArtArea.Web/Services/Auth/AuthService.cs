using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtArea.Web.Controllers;
using ArtArea.Web.Data.Interface;
using Microsoft.AspNetCore.Mvc;
using ArtArea.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace ArtArea.Web.Services.Auth
{
    public class AuthService
    {
        private IUserRepository _userRepository;
        private JwtBearerSettings _jwtBearerSettings;
        public AuthService(
            IUserRepository userRepository,
            JwtBearerSettings jwtBearerSettings)
        {
            _userRepository = userRepository;
            _jwtBearerSettings = jwtBearerSettings;
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
        public Task AddNewUser(User registerUser)
        {
            var user = _userRepository.ReadUser(registerUser.Username);
            return Task.Run(() =>
            {
                if (user != null) throw new Exception("User already exists");
                else _userRepository.CreateUser(registerUser);

            });
        }

        public JwtSecurityToken GetToken(string username)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtBearerSettings.SecretKey));
            var signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>(
                new[]
                {
                    new Claim(ClaimTypes.Name, username)
                }.AsEnumerable()
            );

            var token = new JwtSecurityToken(
                issuer: _jwtBearerSettings.Issuer,
                audience: _jwtBearerSettings.Audience,
                claims: claims,
                signingCredentials: signInCredentials
            );

            return token;
        }
    }
}
