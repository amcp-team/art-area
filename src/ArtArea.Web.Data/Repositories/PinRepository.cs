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
    public class PinRepository : IPinRepository
    {
        private ApplicationDb _database;
        public PinRepository(ApplicationDb database)
            => _database = database;

        #region Synchronous
        public void CreatePin(Pin pin)
        {
            throw new NotImplementedException();
        }

        public void DeletePin(string id)
        {
            throw new NotImplementedException();
        }

        public Pin ReadPin(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pin> ReadPins()
        {
            throw new NotImplementedException();
        }

        public void UpdatePin(Pin pin)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Asynchronous
        public Task CreatePinAsync(Pin pin)
            => _database.Pins.InsertOneAsync(pin);

        public  Task DeletePinAsync(string id)
            => _database.Pins.DeleteOneAsync(id);

        public  Task<Pin> ReadPinAsync(string id)
            => _database.Pins.Find(x => x.Id == id).FirstOrDefaultAsync();

        public Task<IEnumerable<Pin>> ReadPinsAsync()
            => Task.Run(()=>_database.Pins.Find(x => true).ToEnumerable());

        public Task UpdatePinAsync(Pin pin)
            => _database.Pins.ReplaceOneAsync(new BsonDocument("_id",pin.Id),pin);
        #endregion
    }
}
