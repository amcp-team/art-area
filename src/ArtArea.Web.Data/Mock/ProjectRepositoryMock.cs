using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;

namespace ArtArea.Web.Data.Mock
{
    public class ProjectRepositoryMock : IProjectRepository
    {
        public async Task CreateProject(Project project)
        {
            await Task.Run(() => ApplicationDbMock.Projects.Add(project));
        }

        public async Task DeleteProject(string id)
        {
            await Task.Run(() =>
            {
                var project = ApplicationDbMock.Projects
                    .SingleOrDefault(p => p.Id == id);
                ApplicationDbMock.Projects.Remove(project);
            });
        }

        public async Task<Project> ReadProject(string id)
        {
            return await Task.Run(() => ApplicationDbMock.Projects.SingleOrDefault(p => p.Id == id));
        }

        public async Task<IEnumerable<Project>> ReadProjects()
        {
            return await Task.Run(() => ApplicationDbMock.Projects);
        }

        public async Task UpdateProject(Project project)
        {
            await Task.Run(() =>
            {
                var _project = ApplicationDbMock.Projects.SingleOrDefault(p => p.Id == project.Id);

                if (_project != null)
                    _project = project;
            });
        }
    }
}