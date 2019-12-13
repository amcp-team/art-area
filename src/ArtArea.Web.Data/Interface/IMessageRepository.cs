using ArtArea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArtArea.Web.Data.Interface
{
    public interface IMessageRepository
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
        IQueryable<Models.Message> Filter<Message>(Expression<Func<Models.Message, bool>> predicate);
    }
}
