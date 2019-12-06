using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ArtArea.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PinController : ControllerBase
    {
        private PinService _pinService;
        public PinController(PinService pinService)
            => _pinService = pinService;

        [HttpGet("pins/{id}")]
        public async Task<IActionResult> GetPinData(string id)
        {
            try
            {
                var pin = await _pinService.GetPinAsync(id);
                return new ObjectResult(new
                {
                    id = pin.Id,
                    message= new 
                    {
                        id=pin.Message.Id,
                        text=pin.Message.MarkdownText,
                        date=pin.Message.PublicationDate,
                        author=pin.Message.Author

                    } 
                    

                });
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
                    
    }
}