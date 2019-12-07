using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;
using System.Linq;
using ArtArea.Web.Services.Models;

namespace ArtArea.Web.Services
{
    public class ProjectService
    {
        private IProjectRepository _projectRepository;
        private IBoardRepository _boardRepository;

        public ProjectService(
            IProjectRepository projectRepository,
            IBoardRepository boardRepository)
        {
            _projectRepository = projectRepository;
            _boardRepository = boardRepository;
        }

        public bool ProjectExists(string projectId)
            => _projectRepository.ReadProject(projectId) != null;

        public Task<Project> GetProjectAsync(string projectId)
        {
            if (ProjectExists(projectId))
                return _projectRepository.ReadProjectAsync(projectId);
            else
                throw new Exception("No such project in DB");
        }

        public Task<IEnumerable<Board>> GetProjectBoardsAsync(string projectId)
        {
            if (!ProjectExists(projectId))
                throw new Exception("GetProjectBoards: Project not found in database");

            return Task.Run(async () =>
                (await _boardRepository.ReadBoardsAsync())
                    .Where(x => x.ProjectId == projectId)
                    .AsEnumerable());
        }

       
       public Task CreateProject (CreateProjectModel project)
        {
            if (project != null)
            {
                return _projectRepository.CreateProjectAsync(new Project
                {
                    Title = project.Title,
                    Description = project.Description,
                    IsPrivate = project.IsPrivate

                });
            }
            else throw new Exception("New project is empty");
            
        }
    }
}    