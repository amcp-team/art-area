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
       Task<IEnumerable<Project>> ReadProjects();
       Task<Project> ReadProjectById(string id);
       Task<Project> ReadProjectByName(string name);
       Task CreateProject(Project project);
       Task UpdateProject(Project project);
       Task DeleteProjectById(string id);
       Task DeleteProjectByName(string name);
    }

}