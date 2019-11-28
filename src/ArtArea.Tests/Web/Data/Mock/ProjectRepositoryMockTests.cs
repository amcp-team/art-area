using ArtArea.Web.Data.Mock;
using ArtArea.Web.Data.Interface;
using Xunit;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace ArtArea.Tests.Web.Data.Mock
{
    public class ProjectRepositoryMockTests
    {
        private IProjectRepository _repository = new ProjectRepositoryMock();
        
        [Fact]
        public async Task Test_ReadProjects()
        {
            var projects = await _repository.ReadProjects();

            Assert.Equal(projects, ApplicationDbMock.Projects);
        }

        
        [Fact]
        public async Task Test_ReadProject_Success()
        {
            string projectId = ApplicationDbMock.Projects.FirstOrDefault().Id;
            
            var project = await _repository.ReadProject(projectId);

            Assert.Equal(projectId, project.Id);
        }

        [Fact]
        public async Task Test_ReadProject_Fail()
        {
            var project = await _repository.ReadProject(Guid.NewGuid().ToString());

            Assert.Null(project);
        }
    }
}