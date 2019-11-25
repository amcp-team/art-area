using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;

namespace ArtArea.Web.Data.Mock
{
    // TODO [Andrey] implement all the methods via list
    public class UserRepositoryMock : IUserRepository
    {
        private List<User> users;

        public async Task CreateUser(User user)
        {
            users.Add(user);
        }

        public async Task DeleteUserById(string id)
        {
            var userToDelete = await Task.Run(() =>users.Where(x=>x.Id==id).First() ); 
            users.Remove(userToDelete);
        }
            
        public async Task DeleteUserByName(string name)
        {
            var userToDelete=await Task.Run(()=>users.Where(x=>x.Name==name).First());
            users.Remove(userToDelete);
        }

        public User GetUserById(string id)
        {
            return 
                new User {
                         Id = "1",
                        Name = "Ilya",
                        Login = "ilyakatun",
                        Password = "pass_1",
                        Email = "somemail@mail.cz"

                         }
        }

        public User GetUserByName(string Name)
        {
            return 
                new User {
                         Id = "1",
                        Name = "Ilya",
                        Login = "ilyakatun",
                        Password = "pass_1",
                        Email = "somemail@mail.cz"

                         }
        }

        public async Task<IEnumerable<User>> GetUsers()
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

        public async Task UpdateUserById(string id, User user)
        {
            var userToUpdate=await Task.Run(()=>users.Where(x=>x.Id==id).First());
            users.Where(x=>x.Id==id)
        }

        public async Task UpdateUserByName(string name, User user)
        {
            throw new System.NotImplementedException();
        }
    }
}