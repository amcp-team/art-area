using System;
using System.Threading.Tasks;
using ArtArea.Web.Data.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ArtArea.Models;
using System.Collections.Generic;
using System.Security.Claims;
using ArtArea.Web.Services;
using Microsoft.AspNetCore.Authorization;

namespace ArtArea.Web.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private UserService _userService;

        public UserController(UserService userService)
            => _userService = userService;

        [HttpGet("data/{username}")]
        public async Task<IActionResult> GetUserData(string username)
        {
            try
            {
                var user = await _userService.GetUserAsync(username);
                return new ObjectResult(new
                {
                    username = user.Username,
                    email = user.Email,
                    name = user.Name
                });
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("projects/{username}")]
        public async Task<IActionResult> GetUserProjects(string username)
        {
            try
            {
                var result = (await _userService.GetUserProjects(username, User.Identity.Name))
                    .Select(x => new
                    {
                        title = x.Title,
                        id = x.Id,
                        author = x.HostUsername,
                        description = x.Description
                    })
                    .ToList();

                return new ObjectResult(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}