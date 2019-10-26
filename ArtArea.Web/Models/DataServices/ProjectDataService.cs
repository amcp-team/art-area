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

        public async Task AddProject(Project project) 
            => await db.Projects.InsertOneAsync(project);

        public async Task DeleteProject(string id) 
            => await db.Projects.DeleteOneAsync(x => x.Id == id);

        public async Task<Project> GetProject(string id) 
            => await db.Projects.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<Project>> GetProjects() 
            => await db.Projects.Find(x => true).ToListAsync();

        public async Task UpdateProject(Project project) 
            => await db.Projects.ReplaceOneAsync(new BsonDocument("id", project.Id),project);
    }
}
