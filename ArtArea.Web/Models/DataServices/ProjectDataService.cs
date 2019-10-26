using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ArtArea.Web.Models.DataServices
{
    public class ProjectDataService : IProjectDataService
    {
        public ApplicationDb db;
        public ProjectDataService(ApplicationDb database) => db = database;

        public async Task AddProject(Project project) => await db.Projects.InsertOneAsync(project);

        public async Task DeleteProject(string id) => await db.Projects.DeleteOneAsync(x => x.Id == new ObjectId(id));

        public Task<Project> GetProject(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Project>> GetProjects()
        {
            throw new NotImplementedException();
        }

        public Task UpdateProject(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
