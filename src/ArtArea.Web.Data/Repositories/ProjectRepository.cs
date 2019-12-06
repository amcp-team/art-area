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

        public void CreateProject(Project project)
        {
            throw new System.NotImplementedException();
        }

        public async Task CreateProjectAsync(Project project)
            => await _database.Projects.InsertOneAsync(project);

        public void DeleteProject(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteProjectAsync(string id)
            => await _database.Projects.DeleteOneAsync(x => x.Id == id);

        public Project ReadProject(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Project> ReadProjectAsync(string id)
            => await _database.Projects.Find(x => x.Id == id).FirstOrDefaultAsync();

        public IEnumerable<Project> ReadProjects()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Project>> ReadProjectsAsync()
            => await _database.Projects.Find(x => true).ToListAsync();

        public void UpdateProject(Project project)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateProjectAsync(Project project)
            => await _database.Projects.ReplaceOneAsync(new BsonDocument("_id", project.Id), project);
    }

}