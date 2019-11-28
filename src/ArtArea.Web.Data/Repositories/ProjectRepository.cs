using System.Collections.Generic;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data;
using ArtArea.Web.Data.Interface;
using MongoDB.Bson;
using MongoDB.Driver;

public class ProjectRepository : IProjectRepository
{
    public ApplicationDb db;
    ProjectRepository(ApplicationDb database) => db = database;
    public async Task CreateProject(Project project)
        => await db.Projects.InsertOneAsync(project);

    public async Task DeleteProject(string id)
        => await db.Projects.DeleteOneAsync(x => x.Id == id);

    public async Task<Project> ReadProject(string id)
        => await db.Projects.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task<IEnumerable<Project>> ReadProjects()
        => await db.Projects.Find(x => true).ToListAsync();

    public async Task UpdateProject(Project project)
        => await db.Projects.ReplaceOneAsync(new BsonDocument("id", project.Id), project);
}
