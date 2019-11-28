using System.Threading.Tasks;
using ArtArea.Web.Data.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ArtArea.Models;
using System.Collections.Generic;

namespace ArtArea.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;
        private IProjectRepository _projects;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUserData(string username)
        {
            var user = await _userRepository.ReadUser(username);

            if(user == null)
                return NotFound();

            return new ObjectResult(new {
                username = user.Username,
                email = user.Email,
                name = user.Name
            });
        }
        [HttpGet("{projects}")]
        public async Task<IActionResult> GetUserProjects(string username)
        {
            var user = await _userRepository.ReadUser(username);
            var projects = await _projects.ReadProjects();

            if (user == null) return NotFound();

            List<string> listOfProjects = new List<string>();
          
            foreach(Project project in projects)
            {
                if (project.Collaborators.Any(u => u.Username == username))
                    listOfProjects.Add(project.Title);

            }
            return new ObjectResult(listOfProjects);
           
            

        }
    }
}