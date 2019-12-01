using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ArtArea.Web.Services;

namespace ArtArea.Web.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private ProjectService _projectService;
        public ProjectController(ProjectService projectService)
            => _projectService = projectService;

        [HttpGet("data/{id}")]
        public async Task<IActionResult> GetProjectData(string id)
        {
            try
            {
                var project = await _projectService.GetProjectAsync(id);

                return new ObjectResult(new
                {
                    title = project.Title,
                    id = project.Id,
                    author = project.HostUsername,
                    description = project.Description

                }); ;
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("boards/{id}"), Produces("application/json")]
        public async Task<IActionResult> GetProjectBoards(string id)
        {
            // TODO we should validate logged in user & output only boards that user has access to
            try
            {
                return new ObjectResult(
                    (await _projectService.GetProjectBoardsAsync(id))
                    .Select(x => new
                    {
                        title = x.Title,
                        id = x.Id,
                        description = x.Description
                    }
                ));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}