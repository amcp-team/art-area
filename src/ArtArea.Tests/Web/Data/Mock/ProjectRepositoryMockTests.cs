using ArtArea.Web.Data.Mock;
using ArtArea.Web.Data.Interface;
using Xunit;
using System.Threading.Tasks;
using System.Linq;
using System;
using ArtArea.Models;

namespace ArtArea.Tests.Web.Data.Mock
{
    public class ProjectRepositoryMockTests
    {
        private IProjectRepository _repository = new ProjectRepositoryMock();

        #region Read Tests

        [Fact]
        public async Task Test_ReadProjects()
        {
            var projects = await _repository.ReadProjectsAsync();

            Assert.Equal(projects, ApplicationDbMock.Projects);
        }


        [Fact]
        public async Task Test_ReadProject_Success()
        {
            string projectId = ApplicationDbMock.Projects.FirstOrDefault().Id;

            var project = await _repository.ReadProjectAsync(projectId);

            Assert.Equal(projectId, project.Id);
        }

        [Fact]
        public async Task Test_ReadProject_Fail()
        {
            var project = await _repository.ReadProjectAsync("");

            Assert.Null(project);
        }

        #endregion

        #region Create Tests

        [Fact]
        public async Task Test_CreateProject_Success()
        {
            var newProject = new Project
            {
                Id = "testProjectId"
            };

            await _repository.CreateProjectAsync(newProject);

            Assert.Contains(ApplicationDbMock.Projects, p => p.Id == newProject.Id);

            ApplicationDbMock.Initialize();
        }

        [Fact]
        public async Task Test_CreateProject_Fail()
        {
            var projectFail = ApplicationDbMock.Projects.FirstOrDefault();

            await Assert.ThrowsAnyAsync<Exception>(new Func<Task>(() => _repository.CreateProjectAsync(projectFail)));
        }

        #endregion

        #region Delete Tests

        [Fact]
        public async Task Test_DeleteProject_Success()
        {
            var projectToDeleteId = ApplicationDbMock.Projects.FirstOrDefault().Id;

            await _repository.DeleteProjectAsync(projectToDeleteId);

            Assert.DoesNotContain(ApplicationDbMock.Projects, x => x.Id == projectToDeleteId);
            Assert.DoesNotContain(ApplicationDbMock.Boards, x => x.ProjectId == projectToDeleteId);

            ApplicationDbMock.Initialize();
        }

        [Fact]
        public async Task Test_DeleteProject_Fail()
        {
            await Assert.ThrowsAnyAsync<Exception>(new Func<Task>(() => _repository.DeleteProjectAsync("")));
        }

        #endregion

        #region Update Tests

        [Fact]
        public async Task Test_UpdateProject_Success()
        {
            var projectToUpdate = ApplicationDbMock.Projects.FirstOrDefault();

            projectToUpdate.Description = "1234";

            await _repository.UpdateProjectAsync(projectToUpdate);

            Assert.Equal(
                projectToUpdate.Description,
                ApplicationDbMock.Projects.SingleOrDefault(x => x.Id == projectToUpdate.Id).Description);

            ApplicationDbMock.Initialize();
        }

        [Fact]
        public async Task Test_UpdateProject_Fail()
        {
            await Assert.ThrowsAnyAsync<Exception>(
                new Func<Task>(() => _repository.UpdateProjectAsync(new Project { Id = "" })));
        }

        #endregion
    }
}