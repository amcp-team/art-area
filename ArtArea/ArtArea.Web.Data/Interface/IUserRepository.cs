using System.Collections.Generic;
using ArtArea.Models;

namespace ArtArea.Web.Data.Interface
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserById(string id);
        User GetUserByName(string Name);
        string CreateUser(User user);
        void UpdateUserById(string id, User user);
        void UpdateUserByName(string name, User user);
        void DeleteUserById(string id);
        void DeleteUserByName(string id);
    }
}
