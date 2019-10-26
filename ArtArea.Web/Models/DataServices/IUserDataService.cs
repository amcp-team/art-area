using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtArea.Web.Models.DataServices
{
    interface IUserDataService
    {
        Task AddUser(User user);
        Task DeleteUser(string id);
        Task UpdateUser(User user);
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(string id);
    }
}
