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
    [Route("api/message/test")]
    public class TestMessageCrudController : ControllerBase
    {
        private IMessageRepository _messageRepository;
        public TestMessageCrudController(IMessageRepository messageRepository)
            => _messageRepository = messageRepository;
        [HttpGet("{id}")]
        public async Task<Message> GetMessage(string id)
            => await _messageRepository.ReadMessageAsync(id);
        [HttpGet]
        public async Task<IEnumerable<Message>> GetMessages()
            => await _messageRepository.ReadMessagesAsync();
        [HttpPost]
        public async Task PostMessage([FromBody]Message message)
            => await _messageRepository.CreateMessageAsync(message);
        [HttpPut]
        public async Task PutMessage([FromBody]Message message)
            => await _messageRepository.UpdateMessageAsync(message);
        [HttpDelete("{id}")]
        public async Task DeleteMessage(string id)
            => await _messageRepository.DeleteMessageAsync(id);
    }
}