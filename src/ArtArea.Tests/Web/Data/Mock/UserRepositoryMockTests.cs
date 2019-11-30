using System;
using System.Linq;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;
using ArtArea.Web.Data.Mock;
using Xunit;

namespace ArtArea.Tests.Web.Data.Mock
{
    [Collection("Sequential")]
    public class UserRepositoryMockTests
    {
        private IUserRepository _repository = new UserRepositoryMock();

        #region Read Tests

        [Fact]
        public async Task Test_ReadUsers()
        {
            var users = await _repository.ReadUsersAsync();

            Assert.Equal(users, ApplicationDbMock.Users);
        }

        [Fact]
        public async Task Test_ReadUser_Success()
        {
            var username = ApplicationDbMock.Users.FirstOrDefault().Username;

            var user = await _repository.ReadUserAsync(username);

            Assert.Equal(username, user.Username);
        }

        [Fact]
        public async Task Test_ReadUser_Fail()
        {
            var user = await _repository.ReadUserAsync("");

            Assert.Null(user);
        }

        #endregion

        #region Create Tests

        [Fact]
        public async Task Test_CreateUser_Success()
        {
            ApplicationDbMock.Initialize();

            var newUser = new User
            {
                Username = "mark",
                Name = "Mark Masloedov",
                Password = "mmpassword123",
                Email = "maslo@edov.com"
            };

            await _repository.CreateUserAsync(newUser);

            Assert.Contains(ApplicationDbMock.Users, u => u.Username == newUser.Username);

            ApplicationDbMock.Initialize();
        }

        [Fact]
        public async Task Test_CreateUser_Fail()
        {
            var failUser = ApplicationDbMock.Users.FirstOrDefault();

            var createAsyncFunc = new Func<Task>(() => _repository.CreateUserAsync(failUser));

            await Assert.ThrowsAnyAsync<Exception>(createAsyncFunc);
        }

        #endregion

        #region Delete Tests

        [Fact]
        public async Task Test_DeleteUser_Success()
        {
            ApplicationDbMock.Initialize();

            var usernameToDelete = ApplicationDbMock.Users.FirstOrDefault().Username;

            await _repository.DeleteUserAsync(usernameToDelete);

            Assert.DoesNotContain(ApplicationDbMock.Users, u => u.Username == usernameToDelete);
            Assert.DoesNotContain(ApplicationDbMock.Projects, p => p.HostUsername == usernameToDelete);
            Assert.DoesNotContain(ApplicationDbMock.Boards, b => b.Id.Contains(usernameToDelete));

            ApplicationDbMock.Initialize();
        }

        [Fact]
        public async Task Test_DeleteUser_Fail()
        {
            await Assert.ThrowsAnyAsync<Exception>(new Func<Task>(() => _repository.DeleteUserAsync("")));
        }

        #endregion

        #region Update Tests

        [Fact]
        public async Task Test_UpdateUser_Success()
        {
            ApplicationDbMock.Initialize();

            var userToUpdate = ApplicationDbMock.Users.FirstOrDefault();

            userToUpdate.Password = "testpassword";

            await _repository.UpdateUserAsync(userToUpdate);

            Assert.True(ApplicationDbMock.Users.Single(u => u.Username == userToUpdate.Username).Password == "testpassword");

            ApplicationDbMock.Initialize();
        }

        [Fact]
        public async Task Test_UpdateUser_Fail()
        {
            var userUpdateFail = new User
            {
                Username = ""
            };

            await Assert.ThrowsAnyAsync<Exception>(new Func<Task>(() => _repository.UpdateUserAsync(userUpdateFail)));
        }

        #endregion
    }
}