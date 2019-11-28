using System.Collections.Generic;
using System.Threading.Tasks;
using ArtArea.Models;

namespace ArtArea.Web.Data.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ReadUsers();
        Task<User> ReadUser(string name);
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(string name);
    }
}
