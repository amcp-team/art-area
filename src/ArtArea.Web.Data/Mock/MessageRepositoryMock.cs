using ArtArea.Models;
using ArtArea.Web.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtArea.Web.Data.Mock
{
    class MessageRepositoryMock : IMessageRepository
    {
        #region Synchronous

        public void CreateMessage(Message message)
        {
            var messageToCreate = ApplicationDbMock.Messages
                .SingleOrDefault(x => x.Id == message.Id);
            if (messageToCreate == null)
                ApplicationDbMock.Messages.Add(messageToCreate);
            else throw new Exception("Message already exists");

        }
        public void DeleteMessage(string id)
        {
            var messageToDelete = ApplicationDbMock.Messages.SingleOrDefault(x => x.Id == id);
            if (messageToDelete != null)
                ApplicationDbMock.Messages.Remove(messageToDelete);
            else throw new Exception("Can't delete message - one doesn't exist");
        }

        public Message ReadMessage(string id)
        {
            return ApplicationDbMock.Messages.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Message> ReadMessages()
        {
            return ApplicationDbMock.Messages;
        }

        public void UpdateMessage(Message message)
        {
            var messageToUpdate = ApplicationDbMock.Messages
                .SingleOrDefault(x => x.Id == message.Id);
            if (messageToUpdate != null)
                messageToUpdate = message;
            else throw new Exception("Can't update message - no such board exist");
        }
        #endregion

        #region Asynchronous

        public Task CreateMessageAsync(Message message)
        {
            //do you need this exception?
            var messageToCreate = ApplicationDbMock.Messages
                .SingleOrDefault(x => x.Id == message.Id);
            if (messageToCreate == null)
                return Task.Run(() => ApplicationDbMock.Messages.Add(message));
            else throw new Exception("Message already exists");
        }

        public Task DeleteMessageAsync(string id)
        {
            var messageToDelete = ApplicationDbMock.Messages
                .SingleOrDefault(x => x.Id == id);
            if (messageToDelete != null)
                return Task.Run(() => ApplicationDbMock.Messages.Remove(messageToDelete));
            else throw new Exception("Can't delete message - one doesn't exist");

        }

        public Task<Message> ReadMessageAsync(string id)
        {
            return Task.Run(() => ApplicationDbMock.Messages.SingleOrDefault(x => x.Id == id));
        }

        public Task<IEnumerable<Message>> ReadMessagesAsync()
        {
            return Task.Run(() => ApplicationDbMock.Messages.AsEnumerable());
        }

        public Task UpdateMessageAsync(Message message)
        {
            return Task.Run(() =>
            {
                var messageToUpdate = ApplicationDbMock.Messages
                .SingleOrDefault(x => x.Id == message.Id);

                if (messageToUpdate != null)
                    messageToUpdate = message;
                else throw new Exception("Can't update message - no such board exist");
            });
        }
        #endregion
    }
}
