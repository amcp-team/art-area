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
    public class TestUserCrudControler : ControllerBase
    {
        private IUserRepository _userRepository;
        public TestUserCrudControler(IUserRepository userRepository)
            => _userRepository = userRepository;

        [HttpGet("{username}")]
        public async Task<User> GetUser(string username)
        {
            throw new NotImplementedException();
        } 

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task PostUser([FromBody]User user)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task PutUser([FromBody]User user)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{username}")]
        public async Task DeleteUser(string username)
        {
            throw new NotImplementedException();
        }
    }
}