using ArtArea.Models;
using ArtArea.Web.Data.Interface;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArtArea.Web.Data.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private ApplicationDb _database;
        public MessageRepository(ApplicationDb database)
            => _database = database;

        #region Synchronous
        public void CreateMessage(Message message)
            => _database.Messages.InsertOne(message);

        public void DeleteMessage(string id)
            => _database.Messages.DeleteOne(x => x.Id == id);

        public Message ReadMessage(string id)
            => _database.Messages.Find(x => x.Id == id).FirstOrDefault();

        public IEnumerable<Message> ReadMessages()
            => _database.Messages.Find(x => true).ToList();

        public void UpdateMessage(Message message)
            =>_database.Messages.ReplaceOne(new BsonDocument("_id", message.Id), message);

        public IQueryable<ArtArea.Models.Message> Filter<Message>(Expression<Func<ArtArea.Models.Message, bool>> predicate)
        {
            var mongoQuery = _database.Messages.AsQueryable();
            var linqQuery = mongoQuery.AsQueryable();

            return linqQuery.Where(predicate);
        }

        #endregion

        #region Asynchronous
        public Task CreateMessageAsync(Message message)
            => _database.Messages.InsertOneAsync(message);

        public Task DeleteMessageAsync(string id)
            => _database.Messages.DeleteOneAsync(id);

        public Task<Message> ReadMessageAsync(string id)
            => _database.Messages.Find(x => x.Id == id).FirstOrDefaultAsync();

        public Task<IEnumerable<Message>> ReadMessagesAsync()
            => Task.Run(() => _database.Messages.Find(x => true).ToEnumerable());

        public Task UpdateMessageAsync(Message message)
            => _database.Messages.ReplaceOneAsync(new BsonDocument("_id", message.Id), message);
        #endregion
    }
}
