using ArtArea.Models;
using ArtArea.Web.Data.Config;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace ArtArea.Web.Data
{
    public class ApplicationDb
    {
        private IMongoDatabase _database;
        public IGridFSBucket _bucket;
        private ApplicationDbConfig _config;
        public ApplicationDb(ApplicationDbConfig config)
        {
            _config = config;
            var client = new MongoClient(_config.ConnectionString);
            _database = client.GetDatabase(_config.Database);
            _bucket = new GridFSBucket(_database);
        }

        public IGridFSBucket GetBucket()
            => _bucket;

        public IMongoCollection<User> Users => _database.GetCollection<User>("user");
        public IMongoCollection<Project> Projects => _database.GetCollection<Project>("project");
        public IMongoCollection<Board> Boards => _database.GetCollection<Board>("board");
        public IMongoCollection<Pin> Pins => _database.GetCollection<Pin>("pin");
        public IMongoCollection<Message> Messages => _database.GetCollection<Message>("message");



    }
}
