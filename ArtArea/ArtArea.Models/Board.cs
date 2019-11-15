using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ArtArea.Models
{
    struct AccessToBoard
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Access BoardAccess { get; set; }
    }
    class Board
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProjectId { get; set; }
        public List<AccessToBoard> ProjCollab { get; set; }
    }
}
