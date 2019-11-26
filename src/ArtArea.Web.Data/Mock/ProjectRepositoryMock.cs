using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;

namespace ArtArea.Web.Data.Mock
{
    // TODO [Andrey] add list with board models & accessors to it based on interface
    public class ProjectRepositoryMock : IProjectRepository
    {
        public async Task CreateProject(Project project)
        {
            await Task.Run(() => ApplicationDbMock.Projects.Add(project));
        }

        public async Task DeleteProjectById(string id)
        {
            await Task.Run(() => {
                var project = ApplicationDbMock.Projects
                    .Single(p => p.Id == id);
                ApplicationDbMock.Projects.Remove(project);
            });
        }

        public async Task DeleteProjectByName(string name)
        {
            await Task.Run(() => {
                var project = ApplicationDbMock.Projects
                    .Single(p => p.Name == name);
                ApplicationDbMock.Projects.Remove(project);
            });
        }

        public async Task<Project> ReadProjectById(string id)
        {
            return await Task.Run(() => ApplicationDbMock.Projects.Single(p => p.Id == id));
        }

        public async Task<Project> ReadProjectByName(string name)
        {
            return await Task.Run(() => ApplicationDbMock.Projects.Single(p => p.Name == name));
        }

        public async Task<IEnumerable<Project>> ReadProjects()
        {
            return await Task.Run(() => ApplicationDbMock.Projects);
        }

        public async Task UpdateProject(Project project)
        {
            await Task.Run(() =>
            {
                var _project = ApplicationDbMock.Projects.Single(p => p.Id == project.Id);

                if(_project != null)
                    _project = project;
            });
        }
    }
}