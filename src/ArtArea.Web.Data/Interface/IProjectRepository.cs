using System.Collections.Generic;
using System.Threading.Tasks;
using ArtArea.Models;

namespace ArtArea.Web.Data.Interface
{
    // TODO [A] add syncronous method declarations
    public interface IProjectRepository
    {
       Task<IEnumerable<Project>> ReadProjects();
       Task<Project> ReadProject(string id);
       Task CreateProject(Project project);
       Task UpdateProject(Project project);
       Task DeleteProject(string id);
    }

}