using System.Collections.Generic;
using System.Threading.Tasks;
using ArtArea.Models;

namespace ArtArea.Web.Data.Interface
{
    // TODO [A] add syncronous method declarations
    public interface IProjectRepository
    {
        //Asyncronous methods
        Task<IEnumerable<Project>> ReadProjectsAsync();
        Task<Project> ReadProjectAsync(string id);
        Task CreateProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(string id);

        //Syncronous methods
        IEnumerable<Project> ReadProjects();
        Project ReadProject(string id);
        void CreateProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(string id);
    }

}