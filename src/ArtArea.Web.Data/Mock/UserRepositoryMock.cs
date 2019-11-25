using System.Collections.Generic;
using System.Linq;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;

namespace ArtArea.Web.Data.Mock
{
    // TODO [Andrey] implement all the methods via list
    public class UserRepositoryMock : IUserRepository
    {
        public string CreateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteUserById(string id)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteUserByName(string id)
        {
            throw new System.NotImplementedException();
        }

        public User GetUserById(string id)
        {
            throw new System.NotImplementedException();
        }

        public User GetUserByName(string Name)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            // FIXME [Andrew] implement it as field
            return
                new [] {
                    new User {
                        Id = "1",
                        Name = "Ilya",
                        Login = "ilyakatun",
                        Password = "pass_1",
                        Email = "somemail@mail.cz"
                    },
                    new User {
                        Id = "2",
                        Name = "Vika",
                        Login = "vikadzuba",
                        Password = "pass_2",
                        Email = "somemail@mail.cz"
                    },
                    new User {
                        Id = "3",
                        Name = "Andrey",
                        Login = "andreyageev",
                        Password = "pass_3",
                        Email = "somemail@mail.cz"
                    }
                }.AsEnumerable<User>();
        }

        public void UpdateUserById(string id, User user)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUserByName(string name, User user)
        {
            throw new System.NotImplementedException();
        }
    }
}