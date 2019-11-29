using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ArtArea.Web.Controllers.Test
{
    // TODO [A] implement test methods
    // For deletion we should implement cascade deletion - when we delete project =>
    // we delete all the boards inside => when we delete board => we delete 
    // everything board specific inside, etc.

    [ApiController]
    [Route("api/user/test")]
    public class TestUserCrudController : ControllerBase
    {
        private IUserRepository _userRepository;
        public TestUserCrudController(IUserRepository userRepository)
            => _userRepository = userRepository;

        [HttpGet("{username}")]
        public async Task<User> GetUser(string username)
            => await _userRepository.ReadUser(username);

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
            => await _userRepository.ReadUsers();

        [HttpPost]
        public async Task PostUser([FromBody]User user)
            => await _userRepository.CreateUser(user);

        [HttpPut]
        public async Task PutUser([FromBody]User user)
            => await _userRepository.UpdateUser(user);

        [HttpDelete("{username}")]
        public async Task DeleteUser(string username)
            => await _userRepository.DeleteUser(username);
    }
}