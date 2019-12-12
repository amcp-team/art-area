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
            => _database.Pins.InsertOne(pin);

        public void DeletePin(string id)
            => _database.Pins.DeleteOne(x => x.Id == id);

        public Pin ReadPin(string id)
            => _database.Pins.Find(x => x.Id == id).FirstOrDefault();

        public IEnumerable<Pin> ReadPins()
            => _database.Pins.Find(x => true).ToList();

        public void UpdatePin(Pin pin)
            => _database.Pins.ReplaceOne(new BsonDocument("_id", pin.Id), pin);
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
