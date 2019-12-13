using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;
using System.Linq;
using ArtArea.Web.Services.Models;
using ArtArea.Models.Privacy;

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


        public Task<string> CreateProject(CreateProjectModel project, string username)
        {
            if (project != null)
            {
                var projectEntity = new Project
                {
                    Id = username + "." + project.Title.ToLowerInvariant().Replace(' ', '-'),
                    Title = project.Title,
                    Description = project.Description,
                    IsPrivate = project.IsPrivate,
                    HostUsername = username,
                    Collaborators = new List<UserAccess>(new[] {
                        new UserAccess {
                            Username = username,
                            Role = AccessRole.Admin
                        }
                    }),
                    Tags = new List<Tag>()
                };

                return Task.Run(async () =>
                {
                    await _projectRepository.CreateProjectAsync(projectEntity);
                    return projectEntity.Id;
                });
            }
            else throw new Exception("New project is empty");

        }
        public Task DeleteProjectAsync(string projectId)
        {
            if (ProjectExists(projectId))
            {
                return Task.Run(() => _projectRepository.DeleteProjectAsync(projectId));

            }
            else throw new Exception("Project with this id is't exist or has already been deleted");

        }
    }
}