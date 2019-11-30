using System.Collections.Generic;
using System.Threading.Tasks;
using ArtArea.Models;

namespace ArtArea.Web.Data.Interface
{
    // TODO [A] add syncronous method declarations
    public interface IUserRepository
    {
        //Asyncronous methods
        Task<IEnumerable<User>> ReadUsersAsync();
        Task<User> ReadUserAsync(string name);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(string name);

        //Syncronous methods
        IEnumerable<User> ReadUsers();
        User ReadUser(string name);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(string name);

    }
}
