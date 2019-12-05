using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ArtArea.Web.Services;

namespace ArtArea.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private BoardService _boardService;
        public BoardController(BoardService boardService)
            => _boardService = boardService;

        [HttpGet("data/{id}")]
        public  async Task<IActionResult> GetBoardData (string id) 
        {
            try
            {
                var board = await _boardService.GetBoardAsync(id);
                return new ObjectResult(new
                {
                    title = board.Title,
                    id = board.Id,
                    description = board.Description,
                    boardNumber = board.Number

                });
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

          
        }

        [HttpGet("pins/{id}")]
        public async Task <IActionResult> GetPinData
    }
}