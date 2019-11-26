using System.Linq;
using System.Threading.Tasks;
using ArtArea.Web.Data.Interface;
using ArtArea.Web.Data.Mock;
using Xunit;

namespace ArtArea.Tests.Web.Data.Mock
{
    public class UserRepositoryMockTests
    {
        private IUserRepository repository = new UserRepositoryMock();

        [Fact]
        public async Task Test_ReadUsers()
        {
            var users = await repository.ReadUsers();

            Assert.Equal(users, ApplicationDbMock.Users);
        }

        [Fact]
        public async Task Test_ReadUser_Success()
        {
            var username = ApplicationDbMock.Users.FirstOrDefault().Username;

            var user = await repository.ReadUser(username);

            Assert.Equal(username, user.Username);
        }

        [Fact]
        public async Task Test_ReadUser_Fail()
        {
            var user = await repository.ReadUser("invalidusername");

            Assert.Null(user);
        }
    }
}