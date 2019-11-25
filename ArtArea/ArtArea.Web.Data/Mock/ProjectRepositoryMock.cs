using System.Collections.Generic;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;

namespace ArtArea.Web.Data
{
    // TODO [Andrey] add list with board models & accessors to it based on interface
    public class ProjectRepositoryMock : IProjectRepository
    {
        public async Task CreateProject(Project project)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteProjectById(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteProjectByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task GetProjectById(string id)
        {
            return new Project{
                        Id="2",
                        Name="Game",
                        ProjectCollab="Ilya","Sergey"
            }
        }

        public async Task GetProjectByName(string name)
        {
            return new Project{
                 Id="1",
                        Name="Game",
                        ProjectId="1",
                        ProjectCollab="Ilya","Andrey"
            }
        }

        public async Task<IEnumerable<Project>> GetProjects()
        {
            return 
                new[]{
                    new Project{
                        Id="1",
                        Name="Game",
                        ProjectCollab="Ilya","Andrey"
                    },
                    new Project{
                        Id="2",
                        Name="Pirate",
                        ProjectCollab="Ilya","Sergey"
                    }

                }
        }

        public async Task UpdateProjectById(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateProjectByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}