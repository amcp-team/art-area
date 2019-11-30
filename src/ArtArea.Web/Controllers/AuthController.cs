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
        private AuthService _authService;

        public AuthController(
            JwtBearerSettings jwtBearerSettings,
            IUserRepository userRepository,
            AuthService authService)
        {
            _jwtBearerSettings = jwtBearerSettings;
            _userRepository = userRepository;
            _authService = authService;
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
        {
            if(await _authService.CheckUserLogin(userLogin.Username,userLogin.Password))
                {
                   var token = GetToken(userLogin.Username);
             
                   return Ok(new
                 {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiresIn = token.ValidTo,
                    username = userLogin.Username
                 });
                }
               else return Unauthorized();

                    // if (userLogin == null)
                    //     return BadRequest("Invalid client request");
                    // 
                    // var user = await _userRepository.ReadUser(userLogin.Username);
                    // 
                    // if (user != null && user.Password == userLogin.Password)
                    // {
                    //     var token = GetToken(user.Username);
                    // 
                    //     return Ok(new
                    //     {
                    //         token = new JwtSecurityTokenHandler().WriteToken(token),
                    //         expiresIn = token.ValidTo,
                    //         username = user.Username
                    //     });
                    // }
                    // else return Unauthorized();
        }

        [HttpPost, Route("register")]
        public async Task<IActionResult> Register([FromBody] User userRegister)
        {
            /*var user = await _userRepository.ReadUser(userRegister.Username);
            if (user != null)
                return BadRequest();

            await _userRepository.CreateUser(new User
            {
                Username = userRegister.Username,
                Password = userRegister.Password,
                Email = userRegister.Email,
                Name = userRegister.Name
            });*/
            try
            {
                await _authService.AddNewUser(userRegister);
            }
            catch
            {
                return BadRequest();
            }

            var token = GetToken(userRegister.Username);

            return Ok(new {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiresIn = token.ValidTo,
                username = userRegister.Username
            });
        }

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