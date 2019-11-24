using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Art.Models;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;

namespace Art
{

 [Route("api/auth")]
 [ApiController]
 public class AuthController:ControllerBase
 {
     List<LoginModel> users=new List<LoginModel>
     {
         new LoginModel{Login="Andrey",Password="12345"},
         new LoginModel{Login="Ilya",Password="67890"},
         new LoginModel{Login="Sergo",Password="00000"}

     };
    [HttpPost, Route("login")]
    public IActionResult Login([FromBody]LoginModel user)
    { 
        if(user==null)
        {
          return BadRequest("Invalid client request");
        }
        if(user==users.Where(x=>x.Login==user.Login&&x.Password==user.Password).FirstOrDefault())
        {
            var secretKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("superSecretKey@345"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
 
            var tokeOptions = new JwtSecurityToken(
                issuer: "http://localhost:5000",
                audience: "http://localhost:5000",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );
 
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return Ok(new { Token = tokenString });

        }
        else
        {
            return Unauthorized();
        }

    }

 }

}