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
        private IProjectRepository repository = new ProjectRepositoryMock();
        
        [Fact]
        public async Task Test_ReadProjects()
        {
            var projects = await repository.ReadProjects();

            Assert.Equal(projects, ApplicationDbMock.Projects);
        }

        [Fact]
        public async Task Test_ReadProjectByName_Success()
        {
            string projectName = ApplicationDbMock.Projects.FirstOrDefault().Name;

            var project = await repository.ReadProjectByName(projectName);

            Assert.Equal(projectName, project.Name);
        }

        [Fact]
        public async Task Test_ReadProjectByName_Fail()
        {
            var project = await repository.ReadProjectByName("some odd name");

            Assert.Null(project);
        }

        [Fact]
        public async Task Test_ReadProjectById_Success()
        {
            string projectId = ApplicationDbMock.Projects.FirstOrDefault().Id;
            
            var project = await repository.ReadProjectById(projectId);

            Assert.Equal(projectId, project.Id);
        }

        [Fact]
        public async Task Test_ReadProjectById_Fail()
        {
            var project = await repository.ReadProjectById(Guid.NewGuid().ToString());

            Assert.Null(project);
        }
    }
}