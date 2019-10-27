using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtArea.Web.Models
{
    public class Issue
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public ObjectId CreatorId { get; set; }
        //public List<ObjectId> Assignees { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProjectId { get; set; }
    }
}
