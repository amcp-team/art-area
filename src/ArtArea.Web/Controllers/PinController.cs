﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


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

        [HttpPost("create")]
        public async Task<IActionResult> PostNewPin([FromForm] NewPinModel pin)
        {
            try
            {
                var thumbnailId = await _pinService.UploadFile(pin.Thumbnail);
                var sourceFileId = await _pinService.UploadFile(pin.SourceFile);

                var newPin = new Pin
                {
                    Message = new Message
                    {
                        Author = HttpContext.User.Identity.Name,
                        MarkdownText = pin.Message,
                        PublicationDate = DateTime.Now
                    },
                    ThumbnailId = thumbnailId,
                    FileId = sourceFileId
                };

                await _pinService.CreatePinAsync(newPin);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}