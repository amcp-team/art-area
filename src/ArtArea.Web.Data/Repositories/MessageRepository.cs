using ArtArea.Models;
using ArtArea.Web.Data.Interface;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtArea.Web.Data.Repositories
{
    public class MessageRepository:IMessageRepository
    {
        private ApplicationDb _database;
        public MessageRepository(ApplicationDb database)
            => _database = database;

        #region Synchronous
        public void CreateMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public void DeleteMessage(string id)
        {
            throw new NotImplementedException();
        }

        public Message ReadMessage(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> ReadMessages()
        {
            throw new NotImplementedException();
        }

        public void UpdateMessage(Message message)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Asynchronous
        public Task CreateMessageAsync(Message message)
            =>  _database.Messages.InsertOneAsync(message);

        public Task DeleteMessageAsync(string id)
            => _database.Messages.DeleteOneAsync(id);

        public Task<Message> ReadMessageAsync(string id)
            => _database.Messages.Find(x => x.Id == id).FirstOrDefaultAsync();

        public Task<IEnumerable<Message>> ReadMessagesAsync()
            => Task.Run(()=>_database.Messages.Find(x=>true).ToEnumerable());

        public Task UpdateMessageAsync(Message message)
            => _database.Messages.ReplaceOneAsync(new BsonDocument("_id", message.Id),message);
        #endregion
    }
}
