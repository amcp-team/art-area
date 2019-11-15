using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace ArtArea.Web.Data
{
    public class ApplicationDb
    {
        private IMongoDatabase _database;
        private IGridFSBucket _bucket;

        public ApplicationDb()
        {
            var client = new MongoClient();
            _database = client.GetDatabase("artareadb");
            _bucket = new GridFSBucket(_database);
        }

    }
}
