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
    public class TestBoardCrudController : ControllerBase
    {
        private IBoardRepository _boardRepository;
        public TestBoardCrudController(IBoardRepository boardRepository)
            => _boardRepository = boardRepository;

        [HttpGet("{id}")]
        public async Task<Board> GetBoard(string id)
            => await _boardRepository.ReadBoard(id);

        [HttpGet]
        public async Task<IEnumerable<Board>> GetBoards()
            => await _boardRepository.ReadBoards();

        [HttpPost]
        public async Task PostBoard([FromBody]Board board)
            => await _boardRepository.CreateBoard(board);

        [HttpPut]
        public async Task PutBoard([FromBody]Board board)
            => await _boardRepository.UpdateBoard(board);

        [HttpDelete("{id}")]
        public async Task DeleteBoard(string id)
            => await _boardRepository.DeleteBoard(id);
    }
}