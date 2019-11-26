using System.Collections.Generic;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;

namespace ArtArea.Web.Data
{
    // TODO [Andrey] add list with board models & accessors to it based on interface
    public class ProjectRepositoryMock : IProjectRepository
    {
        public async Task CreateProject(Project project)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteProjectById(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteProjectByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task GetProjectById(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task GetProjectByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Project>> GetProjects()
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateProjectById(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateProjectByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}