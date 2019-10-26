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
        Task<Project> GetProject(ObjectId id);
        Task DeleteProject(ObjectId id);
        Task UpdateProject(Project project);
    }
}
