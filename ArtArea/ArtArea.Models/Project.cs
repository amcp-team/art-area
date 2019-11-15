using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ArtArea.Models
{
    struct AccessToProj
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Access ProjectAccess { get; set; }
    }

    class Project
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public List<AccessToProj> ProjCollab { get; set; }
    }
}
