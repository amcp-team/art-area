using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;
using ArtArea.Web.Services.Auth;
using ArtArea.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ArtArea.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private JwtBearerSettings _jwtBearerSettings;
        private IUserRepository _userRepository;

        public AuthController(
            JwtBearerSettings jwtBearerSettings,
            IUserRepository userRepository)
        {
            _jwtBearerSettings = jwtBearerSettings;
            _userRepository = userRepository;
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] UserAuthViewModel userLoginViewModel)
        {
            if (userLoginViewModel == null)
                return BadRequest("Invalid client request");

            var user = await _userRepository.ReadUser(userLoginViewModel.Username);

            if (user != null && user.Password == userLoginViewModel.Password)
            {
                var response = new UserAuthResponseViewModel
                {
                    Username = user.Username,
                    Token = GetToken(user.Username),
                    Successfull = true
                };

                return Ok(response);
            }
            else
            {
                var response = new UserAuthResponseViewModel
                {
                    Successfull = false
                };

                return Unauthorized(response);
            }
        }

        [HttpPost, Route("register")]
        public IActionResult Join([FromBody] UserAuthViewModel userLoginViewModel)
        {
            var response = new UserAuthResponseViewModel
            {
                Successfull = false
            };

            var user = _userRepository.ReadUser(userLoginViewModel.Username);
            if (user != null)
                return BadRequest(response);

            _userRepository.CreateUser(new User
            {
                Username = userLoginViewModel.Username,
                Password = userLoginViewModel.Password,
                Email = "",
                Name = ""
            });

            response.Username = userLoginViewModel.Username;
            response.Token = GetToken(userLoginViewModel.Username);
            response.Successfull = true;

            return Ok(response);
        }

        private string GetToken(string username)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtBearerSettings.SecretKey));
            var signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>(
                new[]
                {
                    new Claim(ClaimTypes.Name, username)
                }.AsEnumerable()
            );

            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtBearerSettings.Issuer,
                audience: _jwtBearerSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddSeconds(30),
                signingCredentials: signInCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}