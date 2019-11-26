using System.Collections.Generic;
using System.Threading.Tasks;
using ArtArea.Models;

namespace ArtArea.Web.Data.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        User GetUserById(string id);
        User GetUserByName(string Name);
        Task CreateUser(User user);
        Task UpdateUserById(string id, User user);
        Task UpdateUserByName(string name, User user);
        Task DeleteUserById(string id);
        Task DeleteUserByName(string id);
    }
}
