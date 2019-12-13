using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ArtArea.Web.Services;
using ArtArea.Web.Services.Models;

namespace ArtArea.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private BoardService _boardService;
        private PinService _pinService;
        public BoardController(BoardService boardService,PinService pinService)
        {
            _boardService = boardService;
            _pinService = pinService;

        }
            

        [HttpGet("data/{id}")]
        public async Task<IActionResult> GetBoardData(string id)
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

        [HttpPost("create")]
        public async Task<IActionResult> CreateBoard([FromBody]CreateBoardModel board)
        {
            try
            {
                var username = HttpContext.User.Identity.Name;

                if (username == null)
                    return Unauthorized();

                var id = await _boardService.CreateBoardAsync(board, username);

                return Ok(id);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }

        [HttpGet("pins/{id}")]
        public async Task<IActionResult> GetPins(string id)
        {
            try 
            {
                return new ObjectResult(

                    (await _boardService.GetPinsAsync(id))
                    .Select(x => new
                    {
                        id = x.Id,
                        message = x.Message,
                        thumbnailId = x.ThumbnailId
                    }
                    ));
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }
}