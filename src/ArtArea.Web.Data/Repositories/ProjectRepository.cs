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
        public ProjectRepository(ApplicationDb database) => _database = database;

        #region Synchronous
        public void CreateProject(Project project)
            => _database.Projects.InsertOne(project);

        public void DeleteProject(string id)
            => _database.Projects.DeleteOne(x => x.Id == id);

        public Project ReadProject(string id)
            => _database.Projects.Find(x => x.Id == id).FirstOrDefault();

        public IEnumerable<Project> ReadProjects()
            => _database.Projects.Find(x => true).ToList();

        public void UpdateProject(Project project)
            => _database.Projects.ReplaceOne(new BsonDocument("_id", project.Id), project);
        #endregion

        #region Asynchronous
        public Task CreateProjectAsync(Project project)
            => _database.Projects.InsertOneAsync(project);

        public Task DeleteProjectAsync(string id)
            => _database.Projects.DeleteOneAsync(x => x.Id == id);

        public Task<Project> ReadProjectAsync(string id)
            => _database.Projects.Find(x => x.Id == id).FirstOrDefaultAsync();

        public Task<IEnumerable<Project>> ReadProjectsAsync()
            => Task.Run(()=>_database.Projects.Find(x => true).ToEnumerable());

        public Task UpdateProjectAsync(Project project)
            => _database.Projects.ReplaceOneAsync(new BsonDocument("_id", project.Id), project);
        #endregion
    }

}