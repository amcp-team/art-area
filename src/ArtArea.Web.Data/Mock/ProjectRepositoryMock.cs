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

        public async Task CreateProject(Project project)
        {
            await Task.Run(() =>
             {
                 if (ApplicationDbMock.Projects.Any(x => x.Id == project.Id))
                     throw new Exception("Can't create project it already exists");

                 ApplicationDbMock.Projects.Add(project);
             });
        }

        public async Task DeleteProject(string id)
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
                        _boardRepository.DeleteBoard(board.Id);

                    ApplicationDbMock.Projects.Remove(project);
                }
                else throw new Exception("Can't delete project - it doesn't exist");
            });
        }

        public async Task<Project> ReadProject(string id)
        {
            return await Task.Run(() => ApplicationDbMock.Projects.SingleOrDefault(p => p.Id == id));
        }

        public async Task<IEnumerable<Project>> ReadProjects()
        {
            return await Task.Run(() => ApplicationDbMock.Projects);
        }

        public async Task UpdateProject(Project project)
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