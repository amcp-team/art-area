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
        public BoardController(BoardService boardService)
        {
            _boardService = boardService;
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
                    description = board.Description
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
                var pins = await _boardService.GetPinsAsync(id);
                return new ObjectResult(pins.Select(x => new
                {
                    id = x.Id,
                    description = x.Message.MarkdownText,
                    thumbnailId = x.ThumbnailId
                }));

            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }
}