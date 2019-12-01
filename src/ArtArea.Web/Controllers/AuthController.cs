using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace ArtArea.Web.Controllers
{
    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    [ApiController, Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
        {
            if (await _authService.CheckUserLogin(userLogin.Username, userLogin.Password))

            {
                var token = _authService.GetToken(userLogin.Username);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiresIn = token.ValidTo,
                    username = userLogin.Username
                });
            }
            else return Unauthorized();
        }

        [HttpPost, Route("register")]
        public async Task<IActionResult> Register([FromBody] User userRegister)
        {
            try
            {
                await _authService.AddNewUser(userRegister);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            var token = _authService.GetToken(userRegister.Username);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiresIn = token.ValidTo,
                username = userRegister.Username
            });
        }
    }
}