using System.Collections.Generic;
using System.Threading.Tasks;
using ArtArea.Models;

namespace ArtArea.Web.Data.Interface
{

    // TODO [Andrey] CRUD interface for project entity in db
    //      - get by id, (hostUserName, name), (hostUserId, name)
    //      - post with board object
    //      - edit by id
    //      - delete by id
    public interface IProjectRepository
    {
       Task<IEnumerable<Project>> GetProjects();
       Task<Project> GetProjectById(string id);
       Task<Project> GetProjectByName(string name);
       Task CreateProject(Project project);
       Task UpdateProjectById(string id);
       Task UpdateProjectByName(string name);
       Task DeleteProjectById(string id);
       Task DeleteProjectByName(string name);
    }

}