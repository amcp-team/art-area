using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace ArtArea.Web.Controllers
{
    public class NewPinModel
    {
        [Required]
        public string Message { get; set; }
        [Required]
        public IFormFile Thumbnail { get; set; }
        [Required]
        public IFormFile SourceFile { get; set; }

    }

    [Route("api/[controller]")]
    [ApiController]
    public class PinController : ControllerBase
    {
        private PinService _pinService;

        public PinController(PinService pinService)
            => _pinService = pinService;

        [HttpGet("data/{id}")]
        public async Task<IActionResult> GetPinData(string id)
        {
            try
            {
                var pin = await _pinService.GetPinAsync(id);
                return new ObjectResult(new
                {
                    id = pin.Id,
                    message = new
                    {
                        id = pin.Message.Id,
                        text = pin.Message.MarkdownText,
                        date = pin.Message.PublicationDate,
                        author = pin.Message.Author

                    }
                });
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("create/{boardId}")]
        public async Task<IActionResult> PostNewPin([FromForm] NewPinModel pin, string boardId)
        {
            try
            {
                var thumbnailId = _pinService.UploadFile(pin.Thumbnail);
                var sourceFileId = _pinService.UploadFile(pin.SourceFile);

                var newPin = new Pin
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Message = new Message
                    {
                        Author = HttpContext.User.Identity.Name,
                        MarkdownText = pin.Message,
                        PublicationDate = DateTime.Now
                    },
                    ThumbnailId = thumbnailId,
                    FileId = sourceFileId,
                    Messages = new List<string>()
                };

                await _pinService.CreatePinAsync(newPin);

                // TODO add pin to corresponding board
                _pinService.BindPinToBoard(boardId, newPin.Id);

                return Ok(new { pinId = newPin.Id });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpGet("messages/{id}")]
        public async Task<IActionResult> GetPinMessages(string id)
        {
            try
            {
                var result = await _pinService.GetPinMessagesAsync(id);

                return new ObjectResult(result
                    .Select(x => new
                    {
                        username = x.Author,
                        message = x.MarkdownText,
                        publicationDate = x.PublicationDate
                    }
                    ));


            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }

        [HttpGet("thumbnail/{pinId}")]
        public async Task<IActionResult> GetPinThumbnail(string pinId)
        {
            var pin = await _pinService.GetPinAsync(pinId);

            var base64 = "data:image/jpeg;base64," + _pinService.GetBase64Thumbnail(pin.ThumbnailId);

            return new ObjectResult(new { base64 = base64 });
        }

        [HttpPost("message/{pinId}")]
        public IActionResult CreateNewMessage([FromForm] MessageForm message, string pinId)
        {
            var username = User.Identity.Name;

            if (username == null)
                return BadRequest();

            var messageToSave = new Message
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Author = username,
                PublicationDate = DateTime.Now,
                MarkdownText = message.Message
            };
            try
            {
                _pinService.CreateNewMessage(messageToSave, pinId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }
    }

    public class MessageForm
    {
        public string Message { get; set; }
    }
}