using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtArea.Web.Models
{
    public class File
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string RealId { get; set;}
        public string NameVersion { get; set; }
        public DateTime DateCreation { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string IssueId { get; set; }
        public string Type { get; set; }
    }
}
