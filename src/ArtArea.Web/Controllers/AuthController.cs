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
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ArtArea.Web.Controllers
{
    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

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
        public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
        {
            if (userLogin == null)
                return BadRequest("Invalid client request");

            var user = await _userRepository.ReadUser(userLogin.Username);

            if (user != null && user.Password == userLogin.Password)
            {
                var token = GetToken(user.Username);

                return Ok(new {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiresIn = token.ValidTo,
                    username = user.Username
                });
            }
            else return Unauthorized();
        }

        // [HttpPost, Route("register")]
        // public async Task<IActionResult> Register([FromBody] User userForm)
        // {
        //     var user = await _userRepository.ReadUser(userForm.Username);
        //     if (user != null)
        //         return BadRequest(response);

        //     await _userRepository.CreateUser(new User
        //     {
        //         Username = userForm.Username,
        //         Password = userForm.Password,
        //         Email = userForm.Email,
        //         Name = userForm.Name
        //     });

        //     response.Username = userForm.Username;
        //     response.Token = GetToken(userForm.Username);
        //     response.Successfull = true;

        //     return Ok(response);
        // }

        private JwtSecurityToken GetToken(string username)
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
                expires: DateTime.Now.AddSeconds(30),
                signingCredentials: signInCredentials
            );

            return token;
        }
    }
}