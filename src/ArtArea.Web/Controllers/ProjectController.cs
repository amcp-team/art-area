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
        private IBoardRepository _boardRepository;
        public ProjectController(
            IProjectRepository projectRepository,
            IBoardRepository boardRepository)
        {
            _projectRepository = projectRepository;
            _boardRepository = boardRepository;
        }

        [Produces("application/json")]
        [HttpGet("data/{id}")]
        public async Task<IActionResult> GetProject(string id)
        {
            var project = await _projectRepository.ReadProjectAsync(id);

            if (project == null) return NotFound();

            return new ObjectResult(new
            {
                title = project.Title,
                id = project.Id,
                author = project.HostUsername,
                description = project.Description

            }); ;
        }

        [Produces("application/json")]
        [HttpGet("boards/{id}")]
        public async Task<IActionResult> GetProjectBoards(string id)
        {
            var project = await _projectRepository.ReadProjectAsync(id);

            if (project == null) return NotFound("No project with such id");

            return new ObjectResult((await _boardRepository.ReadBoardsAsync())
                .Where(x => x.ProjectId == id)
                .Select(x => new
                {
                    title = x.Title,
                    id = x.Id,
                    description = x.Description
                }));
        }
    }
}