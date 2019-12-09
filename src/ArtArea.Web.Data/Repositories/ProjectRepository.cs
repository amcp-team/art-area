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

        #region Synchronous
        public void CreateProject(Project project)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteProject(string id)
        {
            throw new System.NotImplementedException();
        }

        public Project ReadProject(string id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Project> ReadProjects()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateProject(Project project)
        {
            throw new System.NotImplementedException();
        }
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