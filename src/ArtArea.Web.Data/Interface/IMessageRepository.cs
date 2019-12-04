using ArtArea.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtArea.Web.Data.Interface
{
    interface IMessageRepository
    {
        Task<IEnumerable<Message>> ReadMessagesAsync();
        Task<Message> ReadMessageAsync(string id);
        Task CreateMessageAsync(Message message);
        Task UpdateMessageAsync(Message message);
        Task DeleteMessageAsync(string id);

        IEnumerable<Message> ReadMessages();
        Message ReadMessage(string id);
        void CreateMessage(Message message);
        void UpdateMessage(Message message);
        void DeleteMessage(string id);
    }
}
