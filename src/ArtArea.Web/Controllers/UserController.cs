using System.Threading.Tasks;
using ArtArea.Web.Data.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ArtArea.Models;
using System.Collections.Generic;
using System.Security.Claims;
using ArtArea.Web.Services;

namespace ArtArea.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;
        private IProjectRepository _projectRepository;
        private UserService _userService;

        public UserController(IUserRepository userRepository, IProjectRepository projectRepository,UserService userService)
        {
            _userRepository = userRepository;
            _projectRepository = projectRepository;
            _userService = userService;
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUserData(string username)
        {
            //var user = await _userRepository.ReadUser(username);

            // if (user == null)
            //return NotFound();
            try
                {
                    var user = await _userService.GetUser(username);
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

        [Produces("application/json")]
        [HttpGet("projects/{username}")]
        public async Task<IActionResult> GetUserProjects(string username)
        {
            var user = await _userRepository.ReadUser(username);

            if (user == null)
                return NotFound();

            var claim = User.Claims
                .SingleOrDefault(x => x.ValueType == ClaimTypes.Name);
            string requesterUsername = null;

            if (claim != null)
                requesterUsername = claim.Value;

            var projects = await _projectRepository.ReadProjects();

            var result = projects
                .Where(x => x.Collaborators.Any(y =>
                    y.Username == username && y.Username == (requesterUsername ?? y.Username) ||
                    y.Username == username && !x.IsPrivate))
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
    }
}