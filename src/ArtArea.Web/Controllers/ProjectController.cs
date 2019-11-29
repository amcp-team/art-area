using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ArtArea.Web.Data.Interface;

namespace ArtArea.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
       
        private IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [Produces("application/json")]
        [HttpGet("project/{projectId}")]
        public async Task<IActionResult> GetProject(string id) 
        {
            var projects = await _projectRepository.ReadProjects();
            return new ObjectResult(projects.FirstOrDefault(p=>p.Id==id));
        
        }
    }
}