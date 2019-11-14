using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArtArea.Models
{
    enum Access {Admin=1,Private,Public }

    class ApplicationDb
    {
        private IMongoDatabase database;
        private IGridFSBucket bucket;
        
        public ApplicationDb()
        {
            var client = new MongoClient();
            database = client.GetDatabase("artareadb");
            bucket = new GridFSBucket(database);
        }

    }
}
