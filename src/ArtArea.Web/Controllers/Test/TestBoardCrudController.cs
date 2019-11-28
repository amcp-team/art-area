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
    [Route("api/board/test")]
    public class TestBoardCrudControler : ControllerBase
    {
        private IUserRepository _boardRepository;
        public TestBoardCrudControler(IUserRepository boardRepository)
            => _boardRepository = boardRepository;

        [HttpGet("{id}")]
        public async Task<User> GetBoard(string id)
        {
            throw new NotImplementedException();
        } 

        [HttpGet]
        public async Task<IEnumerable<Board>> GetBoards()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task PostBoard([FromBody]Board board)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task PutBoard([FromBody]Board board)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task DeleteBoard(string id)
        {
            throw new NotImplementedException();
        }
    }
}