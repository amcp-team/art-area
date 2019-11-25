using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using ArtArea.Web.Services.Auth;
using ArtArea.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ArtArea.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        // TODO replace mock list of users with repository accessor
        private List<(string username, string password)> _users = new List<(string username, string password)>((new[]
        {
            (username: "hypnospinner", password: "qwerty123"),
            (username: "AndyS1mpson", password: "somePassword"),
            (username: "admin", password: "adminPassword")
        }).AsEnumerable());
        private JwtBearerSettings _jwtBearerSettings;

        public AuthController(JwtBearerSettings jwtBearerSettings)
            => _jwtBearerSettings = jwtBearerSettings;

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] UserLoginViewModel userLoginViewModel)
        {
            if (userLoginViewModel == null)
                return BadRequest("Invalid client request");

            if (_users.Where(x => x.username == userLoginViewModel.Username && x.password == userLoginViewModel.Password).Any())
                return Ok(new { Token = GetToken(userLoginViewModel.Username) });
            else
                return Unauthorized();
        }

        [HttpPost, Route("join")]
        public IActionResult Join([FromBody] UserLoginViewModel userLoginViewModel)
        {
            if (_users.Where(user => user.username == userLoginViewModel.Username).Any())
                return BadRequest();

            _users.Add((username: userLoginViewModel.Username, password: userLoginViewModel.Password));

            return Ok(new { Token = GetToken(userLoginViewModel.Username) });
        }

        [HttpGet, Authorize, Route("username")]
        public IActionResult GetUsername()
        {
            return Ok(new
            {
                username = User.Claims
                .Where(claim => claim.Type == ClaimTypes.Name)
                .FirstOrDefault()
                .Value
            });
        }

        private string GetToken(string username)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtBearerSettings.SecretKey));
            var signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtBearerSettings.Issuer,
                audience: _jwtBearerSettings.Audience,
                // TODO fix this crutch
                claims: new List<Claim>(new[] { new Claim(ClaimTypes.Name, username) }.AsEnumerable()),
                expires: DateTime.Now.AddSeconds(30),
                signingCredentials: signInCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}