using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtArea.Web.Models.DataServices
{
    interface IProjectDataService
    {
        Task AddProject(Project project);
        Task<IEnumerable<Project>> GetProjects();
        Task<IEnumerable<Project>> GetUserProjects(string projectId);
        Task<Project> GetProject(string id);
        Task DeleteProject(string id);
        Task UpdateProject(Project project);
    }
}
