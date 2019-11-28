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
    public class TestProjectCrudControler : ControllerBase
    {
        private IProjectRepository _projectRepository;
        public TestProjectCrudControler(IProjectRepository projectRepository)
            => _projectRepository = projectRepository;

        [HttpGet("{id}")]
        public async Task<Project> GetProject(string id)
        {

            var result = await _projectRepository.ReadProject(id);
            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<Project>> GetProjects()
                => await _projectRepository.ReadProjects();

        [HttpPost]
        public async Task PostProject([FromBody]Project project)
                => await _projectRepository.CreateProject(project);

        [HttpPut]
        public async Task PutProject([FromBody]Project project)
                => await _projectRepository.UpdateProject(project);

        [HttpDelete("{id}")]
        public async Task DeleteProject(string id)
        {
            var result = _projectRepository.ReadProject(id);
        }
    }
}