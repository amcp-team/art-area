using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ArtArea.Models;

namespace ArtArea.Web.Data.Interface
{
    // TODO [A] add syncronous method declarations
    public interface IUserRepository
    {
        //Asynchronous methods
        Task<IEnumerable<User>> ReadUsersAsync();
        Task<User> ReadUserAsync(string name);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(string name);

        //Synchronous methods
        IEnumerable<User> ReadUsers();
        User ReadUser(string name);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(string name);
        IQueryable<Models.User> Filter<User>(Expression<Func<Models.User, bool>> predicate);
    }
}
