using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ArtArea.Web.Controllers.Test
{
    [ApiController]
    [Route("api/pin/test")]
    public class TestPinCrudController : ControllerBase
    {
        private IPinRepository _pinRepository;
        public TestPinCrudController(IPinRepository pinRepository)
            => _pinRepository = pinRepository;
        [HttpGet("{id}")]
        public async Task<Pin> GetPin(string id)
            => await _pinRepository.ReadPinAsync(id);
        [HttpGet]
        public async Task<IEnumerable<Pin>> GetPins()
            => await _pinRepository.ReadPinsAsync();
        [HttpPost]
        public async Task PostPin([FromBody]Pin pin)
            => await _pinRepository.CreatePinAsync(pin);
        [HttpPut]
        public async Task PutPins([FromBody]Pin pin)
            => await _pinRepository.UpdatePinAsync(pin);
        [HttpDelete("{id}")]
        public async Task DeletePin(string id)
            => await _pinRepository.DeletePinAsync(id);
    }
}