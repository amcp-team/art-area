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
        public async Task<IActionResult> GetProject(string _id) 
        {
            var project = await _projectRepository.ReadProject(_id);

            if (project == null) return NotFound();

            return new ObjectResult(new
            {
                title = project.Title,
                id = project.Id,
                author =project.HostUsername,
                description = project.Description

            }); ;

        
        }
    }
}