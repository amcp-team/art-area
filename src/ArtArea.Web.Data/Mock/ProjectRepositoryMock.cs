using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;

namespace ArtArea.Web.Data.Mock
{
    // TODO [A] fix async/await declaration 
    //      rename asyncronous methods (thhat return task) with Async postfix
    //      create syncronous methods that correspond existsing async
    public class ProjectRepositoryMock : IProjectRepository
    {
        private IBoardRepository _boardRepository = new BoardRepositoryMock();

        public void CreateProject(Project project)
        {
            if (ApplicationDbMock.Projects.Any(x => x.Id == project.Id))
                throw new Exception("Can't create project it already exists");

            ApplicationDbMock.Projects.Add(project);
        }

        public async Task CreateProjectAsync(Project project)
        {
            await Task.Run(() =>
             {
                 if (ApplicationDbMock.Projects.Any(x => x.Id == project.Id))
                     throw new Exception("Can't create project it already exists");

                 ApplicationDbMock.Projects.Add(project);
             });
        }

        public void DeleteProject(string id)
        {
            var projectToDelete = ApplicationDbMock.Projects
                .SingleOrDefault(x => x.Id == id);
            if (projectToDelete != null)
            {
                var boardsToDelete = ApplicationDbMock.Boards.Where(x => x.ProjectId == id);
                foreach (var boards in boardsToDelete)
                    _boardRepository.DeleteBoard(boards.Id);

                ApplicationDbMock.Projects.Remove(projectToDelete);
            }
            else throw new Exception("Can't delete project - it doesn't exist");
        }

        public async Task DeleteProjectAsync(string id)
        {
            await Task.Run(() =>
            {
                var project = ApplicationDbMock.Projects
                    .SingleOrDefault(p => p.Id == id);

                if (project != null)
                {
                    var boardsToDelete = ApplicationDbMock.Boards
                        .Where(board => board.ProjectId == id);

                    foreach(var board in boardsToDelete)
                        _boardRepository.DeleteBoardAsync(board.Id);

                    ApplicationDbMock.Projects.Remove(project);
                }
                else throw new Exception("Can't delete project - it doesn't exist");
            });
        }

        public Project ReadProject(string id)
        {
            return ApplicationDbMock.Projects.SingleOrDefault(x => x.Id == id);
        }
        
        public async Task<Project> ReadProjectAsync(string id)
        {
            return await Task.Run(() => ApplicationDbMock.Projects.SingleOrDefault(p => p.Id == id));
        }

        public IEnumerable<Project> ReadProjects()
        {
            return ApplicationDbMock.Projects;
        }

        public async Task<IEnumerable<Project>> ReadProjectsAsync()
        {
            return await Task.Run(() => ApplicationDbMock.Projects);
        }

        public void UpdateProject(Project project)
        {
            var projectToUpdate = ApplicationDbMock.Projects.SingleOrDefault(x => x.Id == project.Id);
            if (projectToUpdate != null)
                projectToUpdate = project;
            else throw new Exception("Can't update project - it doesn't exist");
        }

        public async Task UpdateProjectAsync(Project project)
        {
            await Task.Run(() =>
            {
                var _project = ApplicationDbMock.Projects.SingleOrDefault(p => p.Id == project.Id);

                if (_project != null)
                    _project = project;
                else throw new Exception("Can't update project - it doesn't exist");
            });
        }
    }
}