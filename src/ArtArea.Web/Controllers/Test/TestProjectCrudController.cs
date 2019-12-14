using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ArtArea.Web.Controllers.Test
{
    // TODO [A] implement test methods
    // For deletion we should implement cascade deletion - when we delete project =>
    // we delete all the boards inside => when we delete board => we delete 
    // everything board specific inside, etc.

    [ApiController]
    [Route("api/project/test")]
    public class TestProjectCrudController : ControllerBase
    {
        private IProjectRepository _projectRepository;
        public TestProjectCrudController(IProjectRepository projectRepository)
            => _projectRepository = projectRepository;

        [HttpGet("{id}")]
        public async Task<Project> GetProject(string id)
            => await _projectRepository.ReadProjectAsync(id);

        [HttpGet]
        public async Task<IEnumerable<Project>> GetProjects()
            => await _projectRepository.ReadProjectsAsync();

        [HttpPost]
        public async Task PostProject([FromBody]Project project)
            => await _projectRepository.CreateProjectAsync(project);

        [HttpPut]
        public async Task PutProject([FromBody]Project project)
            => await _projectRepository.UpdateProjectAsync(project);

        [HttpDelete("{id}")]
        public async Task DeleteProject(string id)
            => await _projectRepository.DeleteProjectAsync(id);
    }
}