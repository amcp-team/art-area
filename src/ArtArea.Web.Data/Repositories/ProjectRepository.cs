using System.Collections.Generic;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ArtArea.Web.Data.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private ApplicationDb _database;
        ProjectRepository(ApplicationDb database) => _database = database;
        public async Task CreateProject(Project project)
            => await _database.Projects.InsertOneAsync(project);

        public async Task DeleteProject(string id)
            => await _database.Projects.DeleteOneAsync(x => x.Id == id);

        public async Task<Project> ReadProject(string id)
            => await _database.Projects.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<Project>> ReadProjects()
            => await _database.Projects.Find(x => true).ToListAsync();

        public async Task UpdateProject(Project project)
            => await _database.Projects.ReplaceOneAsync(new BsonDocument("_id", project.Id), project);
    }

}